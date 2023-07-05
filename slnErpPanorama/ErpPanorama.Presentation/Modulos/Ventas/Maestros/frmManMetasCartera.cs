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
    public partial class frmManMetasCartera : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<MetasCarteraBE> mLista = new List<MetasCarteraBE>();

        #endregion

        #region "Eventos"
        public frmManMetasCartera()
        {
            InitializeComponent();
        }

        private void frmManMetasCartera_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }
        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMetasCarteraEdit objManMetasCartera = new frmManMetasCarteraEdit();
                objManMetasCartera.lstMetasCartera = mLista;
                objManMetasCartera.pOperacion = frmManMetasCarteraEdit.Operacion.Nuevo;
                objManMetasCartera.IdMetasCartera = 0;
                objManMetasCartera.StartPosition = FormStartPosition.CenterParent;
                objManMetasCartera.ShowDialog();
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
                        MetasCarteraBE objE_MetasCartera = new MetasCarteraBE();
                        objE_MetasCartera.IdMetasCartera = int.Parse(gvMetasCartera.GetFocusedRowCellValue("IdMetasCartera").ToString());
                        objE_MetasCartera.Usuario = Parametros.strUsuarioLogin;
                        objE_MetasCartera.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MetasCartera.IdEmpresa = Parametros.intEmpresaId;

                        MetasCarteraBL objBL_MetasCartera = new MetasCarteraBL();
                        objBL_MetasCartera.Elimina(objE_MetasCartera);
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

                //List<ReporteMetasCarteraBE> lstReporte = null;
                //lstReporte = new ReporteMetasCarteraBL().Listado(Parametros.intEmpresaId);

                //if (lstReporte != null)
                //{
                //    if (lstReporte.Count > 0)
                //    {
                //        RptVistaReportes objRptMetasCartera = new RptVistaReportes();
                //        objRptMetasCartera.VerRptMetasCartera(lstReporte);
                //        objRptMetasCartera.ShowDialog();
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
            string _fileName = "ListadoMetasCartera";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMetasCartera.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMetasCartera_DoubleClick(object sender, EventArgs e)
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
            mLista = new MetasCarteraBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMetasCartera.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMetasCartera.DataSource = mLista.Where(obj => obj.DescRuta.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.NombreMes.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMetasCartera.RowCount > 0)
            {
                MetasCarteraBE objMetasCartera = new MetasCarteraBE();
                objMetasCartera.IdMetasCartera = int.Parse(gvMetasCartera.GetFocusedRowCellValue("IdMetasCartera").ToString());

                frmManMetasCarteraEdit objManMetasCarteraEdit = new frmManMetasCarteraEdit();
                objManMetasCarteraEdit.pOperacion = frmManMetasCarteraEdit.Operacion.Modificar;
                objManMetasCarteraEdit.IdMetasCartera = objMetasCartera.IdMetasCartera;
                objManMetasCarteraEdit.StartPosition = FormStartPosition.CenterParent;
                objManMetasCarteraEdit.ShowDialog();

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

            if (gvMetasCartera.GetFocusedRowCellValue("IdMetasCartera").ToString() == "")
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