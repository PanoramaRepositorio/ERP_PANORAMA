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
    public partial class frmManRuta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

       
        private List<RutaBE> mLista = new List<RutaBE>();
        
        #endregion

        #region "Eventos"

        public frmManRuta()
        {
            InitializeComponent();
        }

        private void frmManRuta_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManRutaEdit objManRuta = new frmManRutaEdit();
                objManRuta.lstRuta = mLista;
                objManRuta.pOperacion = frmManRutaEdit.Operacion.Nuevo;
                objManRuta.IdRuta = 0;
                objManRuta.StartPosition = FormStartPosition.CenterParent;
                objManRuta.ShowDialog();
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
                        RutaBE objE_Ruta = new RutaBE();
                        objE_Ruta.IdRuta = int.Parse(gvRuta.GetFocusedRowCellValue("IdRuta").ToString());
                        objE_Ruta.Usuario = Parametros.strUsuarioLogin;
                        objE_Ruta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Ruta.IdEmpresa = Parametros.intEmpresaId;

                        RutaBL objBL_Ruta = new RutaBL();
                        objBL_Ruta.Elimina(objE_Ruta);
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

                List<ReporteRutaBE> lstReporte = null;
                lstReporte = new ReporteRutaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptRuta = new RptVistaReportes();
                        objRptRuta.VerRptRuta(lstReporte);
                        objRptRuta.ShowDialog();
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
            string _fileName = "ListadoRuta";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvRuta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvRuta_DoubleClick(object sender, EventArgs e)
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
            mLista = new RutaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcRuta.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcRuta.DataSource = mLista.Where(obj =>
                                                   obj.DescRuta.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvRuta.RowCount > 0)
            {
                RutaBE objRuta = new RutaBE();
                objRuta.IdRuta = int.Parse(gvRuta.GetFocusedRowCellValue("IdRuta").ToString());

                frmManRutaEdit objManRutaEdit = new frmManRutaEdit();
                objManRutaEdit.pOperacion = frmManRutaEdit.Operacion.Modificar;
                objManRutaEdit.IdRuta = objRuta.IdRuta;
                objManRutaEdit.StartPosition = FormStartPosition.CenterParent;
                objManRutaEdit.ShowDialog();

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

            if (gvRuta.GetFocusedRowCellValue("IdRuta").ToString() == "")
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