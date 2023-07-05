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
    public partial class frmManAnuncio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<AnuncioBE> mLista = new List<AnuncioBE>();
        
        #endregion

        #region "Eventos"

        public frmManAnuncio()
        {
            InitializeComponent();
        }

        private void frmManAnuncio_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManAnuncioEdit objManAnuncio = new frmManAnuncioEdit();
                objManAnuncio.lstAnuncio = mLista;
                objManAnuncio.pOperacion = frmManAnuncioEdit.Operacion.Nuevo;
                objManAnuncio.IdAnuncio = 0;
                objManAnuncio.StartPosition = FormStartPosition.CenterParent;
                objManAnuncio.ShowDialog();
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
                        AnuncioBE objE_Anuncio = new AnuncioBE();
                        objE_Anuncio.IdAnuncio = int.Parse(gvAnuncio.GetFocusedRowCellValue("IdAnuncio").ToString());
                        objE_Anuncio.Usuario = Parametros.strUsuarioLogin;
                        objE_Anuncio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Anuncio.IdEmpresa = Parametros.intEmpresaId;

                        AnuncioBL objBL_Anuncio = new AnuncioBL();
                        objBL_Anuncio.Elimina(objE_Anuncio);
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

            //    List<ReporteAnuncioBE> lstReporte = null;
            //    lstReporte = new ReporteAnuncioBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptAnuncio = new RptVistaReportes();
            //            objRptAnuncio.VerRptAnuncio(lstReporte);
            //            objRptAnuncio.ShowDialog();
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
            string _fileName = "ListadoAnuncioes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvAnuncio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAnuncio_DoubleClick(object sender, EventArgs e)
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
            mLista = new AnuncioBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcAnuncio.DataSource = mLista;
            lblTotalRegistros.Text = gvAnuncio.RowCount.ToString() + " Registros" ;
        }

        private void CargarBusqueda()
        {
            gcAnuncio.DataSource = mLista.Where(obj =>
                                                   obj.DescAnuncio.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvAnuncio.RowCount > 0)
            {
                AnuncioBE objAnuncio = new AnuncioBE();
                objAnuncio.IdAnuncio = int.Parse(gvAnuncio.GetFocusedRowCellValue("IdAnuncio").ToString());
                objAnuncio.Fecha = DateTime.Parse(gvAnuncio.GetFocusedRowCellValue("Fecha").ToString());
                objAnuncio.DescAnuncio = gvAnuncio.GetFocusedRowCellValue("DescAnuncio").ToString();
                objAnuncio.FechaInicio = DateTime.Parse(gvAnuncio.GetFocusedRowCellValue("FechaInicio").ToString());
                objAnuncio.FechaFin = DateTime.Parse(gvAnuncio.GetFocusedRowCellValue("FechaFin").ToString());
                objAnuncio.IdTipoAnuncio = Int32.Parse(gvAnuncio.GetFocusedRowCellValue("IdTipoAnuncio").ToString());
                objAnuncio.Titulo = gvAnuncio.GetFocusedRowCellValue("Titulo").ToString();
                objAnuncio.FlagEstado = Convert.ToBoolean(gvAnuncio.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManAnuncioEdit objManAnuncioEdit = new frmManAnuncioEdit();
                objManAnuncioEdit.pOperacion = frmManAnuncioEdit.Operacion.Modificar;
                objManAnuncioEdit.IdAnuncio = objAnuncio.IdAnuncio;
                objManAnuncioEdit.pAnuncioBE = objAnuncio;
                objManAnuncioEdit.StartPosition = FormStartPosition.CenterParent;
                objManAnuncioEdit.ShowDialog();

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

            if (gvAnuncio.GetFocusedRowCellValue("IdAnuncio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Linea Producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}