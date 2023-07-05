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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManProductoIncentivado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ProductoIncentivadoBE> mLista = new List<ProductoIncentivadoBE>();

        #endregion

        #region "Eventos"

        public frmManProductoIncentivado()
        {
            InitializeComponent();
        }

        private void frmManProductoIncentivado_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManProductoIncentivadoEdit objManProductoIncentivado = new frmManProductoIncentivadoEdit();
                //objManProductoIncentivado. = mLista;
                objManProductoIncentivado.pOperacion = frmManProductoIncentivadoEdit.Operacion.Nuevo;
                objManProductoIncentivado.IdProductoIncentivado = 0;
                objManProductoIncentivado.StartPosition = FormStartPosition.CenterParent;
                objManProductoIncentivado.ShowDialog();
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
                        ProductoIncentivadoBE objE_ProductoIncentivado = new ProductoIncentivadoBE();
                        objE_ProductoIncentivado.IdProductoIncentivado = int.Parse(gvProductoIncentivado.GetFocusedRowCellValue("IdProductoIncentivado").ToString());
                        objE_ProductoIncentivado.Usuario = Parametros.strUsuarioLogin;
                        objE_ProductoIncentivado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ProductoIncentivado.IdEmpresa = Parametros.intEmpresaId;

                        ProductoIncentivadoBL objBL_ProductoIncentivado = new ProductoIncentivadoBL();
                        objBL_ProductoIncentivado.Elimina(objE_ProductoIncentivado);
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

            //    List<ErpPanoramaServicios.ReporteProductoIncentivadoBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteProductoIncentivado_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptProductoIncentivado = new RptVistaReportes();
            //            objRptProductoIncentivado.VerRptProductoIncentivado(lstReporte);
            //            objRptProductoIncentivado.ShowDialog();
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
            string _fileName = "ListadoProductoIncentivado";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProductoIncentivado.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProductoIncentivado_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ProductoIncentivadoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcProductoIncentivado.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcProductoIncentivado.DataSource = mLista.Where(obj =>
                                                   obj.DescProductoIncentivado.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvProductoIncentivado.RowCount > 0)
            {
                ProductoIncentivadoBE objProductoIncentivado = new ProductoIncentivadoBE();
                objProductoIncentivado.IdProductoIncentivado = int.Parse(gvProductoIncentivado.GetFocusedRowCellValue("IdProductoIncentivado").ToString());
                objProductoIncentivado.IdEmpresa = int.Parse(gvProductoIncentivado.GetFocusedRowCellValue("IdEmpresa").ToString());
                objProductoIncentivado.DescProductoIncentivado = gvProductoIncentivado.GetFocusedRowCellValue("DescProductoIncentivado").ToString();
                objProductoIncentivado.FechaInicio = DateTime.Parse(gvProductoIncentivado.GetFocusedRowCellValue("FechaInicio").ToString());
                objProductoIncentivado.FechaFin = DateTime.Parse(gvProductoIncentivado.GetFocusedRowCellValue("FechaFin").ToString());
                objProductoIncentivado.FlagEstado = Convert.ToBoolean(gvProductoIncentivado.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManProductoIncentivadoEdit objManProductoIncentivadoEdit = new frmManProductoIncentivadoEdit();
                objManProductoIncentivadoEdit.pOperacion = frmManProductoIncentivadoEdit.Operacion.Modificar;
                objManProductoIncentivadoEdit.IdProductoIncentivado = objProductoIncentivado.IdProductoIncentivado;
                objManProductoIncentivadoEdit.pProductoIncentivadoBE = objProductoIncentivado;
                objManProductoIncentivadoEdit.StartPosition = FormStartPosition.CenterParent;
                objManProductoIncentivadoEdit.ShowDialog();

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

            if (gvProductoIncentivado.GetFocusedRowCellValue("IdProductoIncentivado").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione ProductoIncentivado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}