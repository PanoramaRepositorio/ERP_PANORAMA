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
    public partial class frmManPromocionValeDescuento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PromocionValeDescuentoBE> mLista = new List<PromocionValeDescuentoBE>();

        #endregion

        #region "Eventos"

        public frmManPromocionValeDescuento()
        {
            InitializeComponent();
        }

        private void frmManPromocionValeDescuento_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPromocionValeDescuentoEdit objManPromocionValeDescuento = new frmManPromocionValeDescuentoEdit();
                //objManPromocionValeDescuento. = mLista;
                objManPromocionValeDescuento.pOperacion = frmManPromocionValeDescuentoEdit.Operacion.Nuevo;
                objManPromocionValeDescuento.IdPromocionValeDescuento = 0;
                objManPromocionValeDescuento.StartPosition = FormStartPosition.CenterParent;
                objManPromocionValeDescuento.ShowDialog();
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
                        PromocionValeDescuentoBE objE_PromocionValeDescuento = new PromocionValeDescuentoBE();
                        objE_PromocionValeDescuento.IdPromocionValeDescuento = int.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdPromocionValeDescuento").ToString());
                        objE_PromocionValeDescuento.Usuario = Parametros.strUsuarioLogin;
                        objE_PromocionValeDescuento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PromocionValeDescuento.IdEmpresa = Parametros.intEmpresaId;

                        PromocionValeDescuentoBL objBL_PromocionValeDescuento = new PromocionValeDescuentoBL();
                        objBL_PromocionValeDescuento.Elimina(objE_PromocionValeDescuento);
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

            //    List<ErpPanoramaServicios.ReportePromocionValeDescuentoBE> lstReporte = null;
            //    lstReporte = objServicio.ReportePromocionValeDescuento_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPromocionValeDescuento = new RptVistaReportes();
            //            objRptPromocionValeDescuento.VerRptPromocionValeDescuento(lstReporte);
            //            objRptPromocionValeDescuento.ShowDialog();
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
            string _fileName = "ListadoPromocionValeDescuento";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocionValeDescuento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPromocionValeDescuento_DoubleClick(object sender, EventArgs e)
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
            mLista = new PromocionValeDescuentoBL().ListaTodosActivo(Parametros.intEmpresaId, 0);
            gcPromocionValeDescuento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPromocionValeDescuento.DataSource = mLista.Where(obj =>
                                                   obj.DescFormaPago.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPromocionValeDescuento.RowCount > 0)
            {
                PromocionValeDescuentoBE objPromocionValeDescuento = new PromocionValeDescuentoBE();
                objPromocionValeDescuento.IdPromocionValeDescuento = int.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdPromocionValeDescuento").ToString());
                objPromocionValeDescuento.IdEmpresa = int.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdEmpresa").ToString());
                objPromocionValeDescuento.Descripcion = gvPromocionValeDescuento.GetFocusedRowCellValue("Descripcion").ToString();
                objPromocionValeDescuento.IdTipoCliente = int.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocionValeDescuento.IdFormaPago = int.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocionValeDescuento.IdTienda = int.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdTienda").ToString());
                objPromocionValeDescuento.FechaInicio = DateTime.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("FechaInicio").ToString());
                objPromocionValeDescuento.FechaFin = DateTime.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("FechaFin").ToString());
                objPromocionValeDescuento.MontoMin = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("MontoMin").ToString());
                objPromocionValeDescuento.MontoMax = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("MontoMax").ToString());
                objPromocionValeDescuento.DescuentoDesde = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("DescuentoDesde").ToString());
                objPromocionValeDescuento.DescuentoHasta = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("DescuentoHasta").ToString());
                objPromocionValeDescuento.DescuentoAdicional = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("DescuentoAdicional").ToString());
                objPromocionValeDescuento.Importe = Decimal.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("Importe").ToString());
                objPromocionValeDescuento.Observacion = gvPromocionValeDescuento.GetFocusedRowCellValue("Observacion").ToString();
                objPromocionValeDescuento.IdTipoPromocion = int.Parse(gvPromocionValeDescuento.GetFocusedRowCellValue("IdTipoPromocion").ToString());
                objPromocionValeDescuento.FlagEstado = Convert.ToBoolean(gvPromocionValeDescuento.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPromocionValeDescuentoEdit objManPromocionValeDescuentoEdit = new frmManPromocionValeDescuentoEdit();
                objManPromocionValeDescuentoEdit.pOperacion = frmManPromocionValeDescuentoEdit.Operacion.Modificar;
                objManPromocionValeDescuentoEdit.IdPromocionValeDescuento = objPromocionValeDescuento.IdPromocionValeDescuento;
                objManPromocionValeDescuentoEdit.pPromocionValeDescuentoBE = objPromocionValeDescuento;
                objManPromocionValeDescuentoEdit.StartPosition = FormStartPosition.CenterParent;
                objManPromocionValeDescuentoEdit.ShowDialog();

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

            if (gvPromocionValeDescuento.GetFocusedRowCellValue("IdPromocionValeDescuento").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione PromocionValeDescuento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}