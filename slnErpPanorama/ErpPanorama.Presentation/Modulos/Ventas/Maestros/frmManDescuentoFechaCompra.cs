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
    public partial class frmManDescuentoFechaCompra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<DescuentoFechaCompraBE> mLista = new List<DescuentoFechaCompraBE>();

        #endregion

        #region "Eventos"

        public frmManDescuentoFechaCompra()
        {
            InitializeComponent();
        }

        private void frmManDescuentoFechaCompra_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManDescuentoFechaCompraEdit objManDescuentoFechaCompra = new frmManDescuentoFechaCompraEdit();
                objManDescuentoFechaCompra.lstDescuentoFechaCompra = mLista;
                objManDescuentoFechaCompra.pOperacion = frmManDescuentoFechaCompraEdit.Operacion.Nuevo;
                objManDescuentoFechaCompra.IdDescuentoFechaCompra = 0;
                objManDescuentoFechaCompra.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoFechaCompra.ShowDialog();
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
                        DescuentoFechaCompraBE objE_DescuentoFechaCompra = new DescuentoFechaCompraBE();
                        objE_DescuentoFechaCompra.IdDescuentoFechaCompra = int.Parse(gvDescuentoFechaCompra.GetFocusedRowCellValue("IdDescuentoFechaCompra").ToString());
                        objE_DescuentoFechaCompra.Usuario = Parametros.strUsuarioLogin;
                        objE_DescuentoFechaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_DescuentoFechaCompra.IdEmpresa = Parametros.intEmpresaId;

                        DescuentoFechaCompraBL objBL_DescuentoFechaCompra = new DescuentoFechaCompraBL();
                        objBL_DescuentoFechaCompra.Elimina(objE_DescuentoFechaCompra);
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

            //    List<ErpPanoramaServicios.ReporteDescuentoFechaCompraBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteDescuentoFechaCompra_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDescuentoFechaCompra = new RptVistaReportes();
            //            objRptDescuentoFechaCompra.VerRptDescuentoFechaCompra(lstReporte);
            //            objRptDescuentoFechaCompra.ShowDialog();
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
            string _fileName = "ListadoDescuentoFechaCompras";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescuentoFechaCompra.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDescuentoFechaCompra_DoubleClick(object sender, EventArgs e)
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
            mLista = new DescuentoFechaCompraBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDescuentoFechaCompra.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDescuentoFechaCompra.DataSource = mLista.Where(obj =>
                                                   obj.DescLineaProducto.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDescuentoFechaCompra.RowCount > 0)
            {
                DescuentoFechaCompraBE objDescuentoFechaCompra = new DescuentoFechaCompraBE();
                objDescuentoFechaCompra.IdDescuentoFechaCompra = int.Parse(gvDescuentoFechaCompra.GetFocusedRowCellValue("IdDescuentoFechaCompra").ToString());
                objDescuentoFechaCompra.IdEmpresa = int.Parse(gvDescuentoFechaCompra.GetFocusedRowCellValue("IdEmpresa").ToString());
                objDescuentoFechaCompra.IdLineaProducto = int.Parse(gvDescuentoFechaCompra.GetFocusedRowCellValue("IdLineaProducto").ToString());
                objDescuentoFechaCompra.FechaInicio = DateTime.Parse(gvDescuentoFechaCompra.GetFocusedRowCellValue("FechaInicio").ToString());
                objDescuentoFechaCompra.FechaFin = DateTime.Parse(gvDescuentoFechaCompra.GetFocusedRowCellValue("FechaFin").ToString());
                objDescuentoFechaCompra.Descuento = decimal.Parse(gvDescuentoFechaCompra.GetFocusedRowCellValue("Descuento").ToString());
                objDescuentoFechaCompra.FlagEstado = Convert.ToBoolean(gvDescuentoFechaCompra.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManDescuentoFechaCompraEdit objManDescuentoFechaCompraEdit = new frmManDescuentoFechaCompraEdit();
                objManDescuentoFechaCompraEdit.pOperacion = frmManDescuentoFechaCompraEdit.Operacion.Modificar;
                objManDescuentoFechaCompraEdit.IdDescuentoFechaCompra = objDescuentoFechaCompra.IdDescuentoFechaCompra;
                objManDescuentoFechaCompraEdit.pDescuentoFechaCompraBE = objDescuentoFechaCompra;
                objManDescuentoFechaCompraEdit.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoFechaCompraEdit.ShowDialog();

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

            if (gvDescuentoFechaCompra.GetFocusedRowCellValue("IdDescuentoFechaCompra").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione DescuentoFechaCompra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion



    }
}