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
    public partial class frmManMetasComision : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MetasComisionBE> mLista = new List<MetasComisionBE>();

        #endregion

        #region "Eventos"
        public frmManMetasComision()
        {
            InitializeComponent();
        }

        private void frmManMetasComision_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMetasComisionEdit objManMetasComision = new frmManMetasComisionEdit();
                objManMetasComision.lstMetasComision = mLista;
                objManMetasComision.pOperacion = frmManMetasComisionEdit.Operacion.Nuevo;
                objManMetasComision.IdMetaComision= 0;
                objManMetasComision.StartPosition = FormStartPosition.CenterParent;
                objManMetasComision.ShowDialog();
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
                        MetasComisionBE objE_MetasComision = new MetasComisionBE();
                        objE_MetasComision.IdMetaComision = int.Parse(gvMetasComision.GetFocusedRowCellValue("IdMetaComision").ToString());
                        objE_MetasComision.Usuario = Parametros.strUsuarioLogin;
                        objE_MetasComision.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MetasComision.IdEmpresa = Parametros.intEmpresaId;

                        MetasComisionBL objBL_MetasComision = new MetasComisionBL();
                        objBL_MetasComision.Elimina(objE_MetasComision);
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteMetasComisionBE> lstReporte = null;
            //    lstReporte = new ReporteMetasComisionBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptMetasComision = new RptVistaReportes();
            //            objRptMetasComision.VerRptMetasComision(lstReporte);
            //            objRptMetasComision.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoMetasComision";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMetasComision.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMetasComision_DoubleClick(object sender, EventArgs e)
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
            mLista = new MetasComisionBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMetasComision.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMetasComision.DataSource = mLista.Where(obj => obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.Cargo.ToUpper().Contains(txtDescripcion.Text.ToUpper()));
        }

        public void InicializarModificar()
        {
            if (gvMetasComision.RowCount > 0)
            {
                MetasComisionBE objMetasComision = new MetasComisionBE();
                objMetasComision.IdMetaComision = int.Parse(gvMetasComision.GetFocusedRowCellValue("IdMetaComision").ToString());

                frmManMetasComisionEdit objManMetasComisionEdit = new frmManMetasComisionEdit();
                objManMetasComisionEdit.pOperacion = frmManMetasComisionEdit.Operacion.Modificar;
                objManMetasComisionEdit.IdMetaComision = objMetasComision.IdMetaComision;
                objManMetasComisionEdit.StartPosition = FormStartPosition.CenterParent;
                objManMetasComisionEdit.ShowDialog();

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

            if (gvMetasComision.GetFocusedRowCellValue("IdMetaComision").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}