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
    public partial class frmManMetaConversion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MetaConversionBE> mLista = new List<MetaConversionBE>();

        #endregion

        #region "Eventos"
        public frmManMetaConversion()
        {
            InitializeComponent();
        }

        private void frmManMetaConversion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }
        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMetaConversionEdit objManMetaConversion = new frmManMetaConversionEdit();
                objManMetaConversion.lstMetaConversion = mLista;
                objManMetaConversion.pOperacion = frmManMetaConversionEdit.Operacion.Nuevo;
                objManMetaConversion.IdMetaConversion = 0;
                objManMetaConversion.StartPosition = FormStartPosition.CenterParent;
                objManMetaConversion.ShowDialog();
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
                        MetaConversionBE objE_MetaConversion = new MetaConversionBE();
                        objE_MetaConversion.IdMetaConversion = int.Parse(gvMetaConversion.GetFocusedRowCellValue("IdMetaConversion").ToString());
                        objE_MetaConversion.Usuario = Parametros.strUsuarioLogin;
                        objE_MetaConversion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MetaConversion.IdEmpresa = Parametros.intEmpresaId;

                        MetaConversionBL objBL_MetaConversion = new MetaConversionBL();
                        objBL_MetaConversion.Elimina(objE_MetaConversion);
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
                //Cursor = Cursors.WaitCursor;

                //List<ReporteMetaConversionBE> lstReporte = null;
                //lstReporte = new ReporteMetaConversionBL().Listado(Parametros.intEmpresaId);

                //if (lstReporte != null)
                //{
                //    if (lstReporte.Count > 0)
                //    {
                //        RptVistaReportes objRptMetaConversion = new RptVistaReportes();
                //        objRptMetaConversion.VerRptMetaConversion(lstReporte);
                //        objRptMetaConversion.ShowDialog();
                //    }
                //    else
                //        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                //Cursor = Cursors.Default;
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
            string _fileName = "ListadoMetaConversion";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMetaConversion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMetaConversion_DoubleClick(object sender, EventArgs e)
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
            mLista = new MetaConversionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMetaConversion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMetaConversion.DataSource = mLista.Where(obj => obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.Mes.ToString().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMetaConversion.RowCount > 0)
            {
                MetaConversionBE objMetaConversion = new MetaConversionBE();
                objMetaConversion.IdMetaConversion = int.Parse(gvMetaConversion.GetFocusedRowCellValue("IdMetaConversion").ToString());

                frmManMetaConversionEdit objManMetaConversionEdit = new frmManMetaConversionEdit();
                objManMetaConversionEdit.pOperacion = frmManMetaConversionEdit.Operacion.Modificar;
                objManMetaConversionEdit.IdMetaConversion = objMetaConversion.IdMetaConversion;
                objManMetaConversionEdit.StartPosition = FormStartPosition.CenterParent;
                objManMetaConversionEdit.ShowDialog();

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

            if (gvMetaConversion.GetFocusedRowCellValue("IdMetaConversion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Unidad de Medida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}