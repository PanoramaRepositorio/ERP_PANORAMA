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

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManInmueble : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<InmuebleBE> mLista = new List<InmuebleBE>();

        #endregion

        #region "Eventos"

        public frmManInmueble()
        {
            InitializeComponent();
        }

        private void frmManInmueble_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManInmuebleEdit objManInmueble = new frmManInmuebleEdit();
                objManInmueble.lstInmueble = mLista;
                objManInmueble.pOperacion = frmManInmuebleEdit.Operacion.Nuevo;
                objManInmueble.IdInmueble = 0;
                objManInmueble.StartPosition = FormStartPosition.CenterParent;
                objManInmueble.ShowDialog();
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
                        InmuebleBE objE_Inmueble = new InmuebleBE();
                        objE_Inmueble.IdInmueble = int.Parse(gvInmueble.GetFocusedRowCellValue("IdInmueble").ToString());
                        objE_Inmueble.Usuario = Parametros.strUsuarioLogin;
                        objE_Inmueble.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Inmueble.IdEmpresa = Parametros.intEmpresaId;

                        InmuebleBL objBL_Inmueble = new InmuebleBL();
                        objBL_Inmueble.Elimina(objE_Inmueble);
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

            //    List<ReporteInmuebleBE> lstReporte = null;
            //    lstReporte = new ReporteInmuebleBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptInmueble = new RptVistaReportes();
            //            objRptInmueble.VerRptInmueble(lstReporte);
            //            objRptInmueble.ShowDialog();
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
            string _fileName = "ListadoInmueblees";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInmueble.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvInmueble_DoubleClick(object sender, EventArgs e)
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
            mLista = new InmuebleBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcInmueble.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcInmueble.DataSource = mLista.Where(obj =>
                                                   obj.DescInmueble.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvInmueble.RowCount > 0)
            {
                InmuebleBE objInmueble = new InmuebleBE();
                objInmueble.IdEmpresa = int.Parse(gvInmueble.GetFocusedRowCellValue("IdEmpresa").ToString());
                objInmueble.IdInmueble = int.Parse(gvInmueble.GetFocusedRowCellValue("IdInmueble").ToString());
                objInmueble.DescInmueble = gvInmueble.GetFocusedRowCellValue("DescInmueble").ToString();
                objInmueble.FlagEstado = Convert.ToBoolean(gvInmueble.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManInmuebleEdit objManInmuebleEdit = new frmManInmuebleEdit();
                objManInmuebleEdit.pOperacion = frmManInmuebleEdit.Operacion.Modificar;
                objManInmuebleEdit.IdInmueble = objInmueble.IdInmueble;
                objManInmuebleEdit.StartPosition = FormStartPosition.CenterParent;
                objManInmuebleEdit.ShowDialog();

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

            if (gvInmueble.GetFocusedRowCellValue("IdInmueble").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Inmueble", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
 
    }
}