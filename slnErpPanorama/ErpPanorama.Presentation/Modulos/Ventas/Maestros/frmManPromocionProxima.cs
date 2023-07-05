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
    public partial class frmManPromocionProxima : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PromocionProximaBE> mLista = new List<PromocionProximaBE>();

        #endregion

        #region "Eventos"
        public frmManPromocionProxima()
        {
            InitializeComponent();
        }

        private void frmManPromocionProxima_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPromocionProximaEdit objManPromocionProxima = new frmManPromocionProximaEdit();
                //objManPromocionProxima. = mLista;
                objManPromocionProxima.pOperacion = frmManPromocionProximaEdit.Operacion.Nuevo;
                objManPromocionProxima.IdPromocionProxima = 0;
                objManPromocionProxima.StartPosition = FormStartPosition.CenterParent;
                objManPromocionProxima.ShowDialog();
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
                        PromocionProximaBE objE_PromocionProxima = new PromocionProximaBE();
                        objE_PromocionProxima.IdPromocionProxima = int.Parse(gvPromocionProxima.GetFocusedRowCellValue("IdPromocionProxima").ToString());
                        objE_PromocionProxima.Usuario = Parametros.strUsuarioLogin;
                        objE_PromocionProxima.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PromocionProxima.IdEmpresa = Parametros.intEmpresaId;

                        PromocionProximaBL objBL_PromocionProxima = new PromocionProximaBL();
                        objBL_PromocionProxima.Elimina(objE_PromocionProxima);
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

            //    List<ErpPanoramaServicios.ReportePromocionProximaBE> lstReporte = null;
            //    lstReporte = objServicio.ReportePromocionProxima_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPromocionProxima = new RptVistaReportes();
            //            objRptPromocionProxima.VerRptPromocionProxima(lstReporte);
            //            objRptPromocionProxima.ShowDialog();
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
            string _fileName = "ListadoPromocionProxima";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPromocionProxima.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPromocionProxima_DoubleClick(object sender, EventArgs e)
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
            mLista = new PromocionProximaBL().ListaTodosActivo(Parametros.intEmpresaId, 0);
            gcPromocionProxima.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcPromocionProxima.DataSource = mLista.Where(obj =>
                                                   obj.DescFormaPago.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPromocionProxima.RowCount > 0)
            {
                PromocionProximaBE objPromocionProxima = new PromocionProximaBE();
                objPromocionProxima.IdPromocionProxima = int.Parse(gvPromocionProxima.GetFocusedRowCellValue("IdPromocionProxima").ToString());
                objPromocionProxima.IdEmpresa = int.Parse(gvPromocionProxima.GetFocusedRowCellValue("IdEmpresa").ToString());
                objPromocionProxima.Descripcion = gvPromocionProxima.GetFocusedRowCellValue("Descripcion").ToString();
                objPromocionProxima.IdTipoCliente = int.Parse(gvPromocionProxima.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objPromocionProxima.IdFormaPago = int.Parse(gvPromocionProxima.GetFocusedRowCellValue("IdFormaPago").ToString());
                objPromocionProxima.IdTienda = int.Parse(gvPromocionProxima.GetFocusedRowCellValue("IdTienda").ToString());
                objPromocionProxima.FechaInicio = DateTime.Parse(gvPromocionProxima.GetFocusedRowCellValue("FechaInicio").ToString());
                objPromocionProxima.FechaFin = DateTime.Parse(gvPromocionProxima.GetFocusedRowCellValue("FechaFin").ToString());
                objPromocionProxima.MontoMin = Decimal.Parse(gvPromocionProxima.GetFocusedRowCellValue("MontoMin").ToString());
                objPromocionProxima.MontoMax = Decimal.Parse(gvPromocionProxima.GetFocusedRowCellValue("MontoMax").ToString());
                objPromocionProxima.FechaDesde = DateTime.Parse(gvPromocionProxima.GetFocusedRowCellValue("FechaDesde").ToString());
                objPromocionProxima.FechaHasta = DateTime.Parse(gvPromocionProxima.GetFocusedRowCellValue("FechaHasta").ToString());
                objPromocionProxima.Descuento = Decimal.Parse(gvPromocionProxima.GetFocusedRowCellValue("Descuento").ToString());
                objPromocionProxima.Mensaje = gvPromocionProxima.GetFocusedRowCellValue("Mensaje").ToString();
                objPromocionProxima.Observacion = gvPromocionProxima.GetFocusedRowCellValue("Observacion").ToString();
                objPromocionProxima.FlagEstado = Convert.ToBoolean(gvPromocionProxima.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPromocionProximaEdit objManPromocionProximaEdit = new frmManPromocionProximaEdit();
                objManPromocionProximaEdit.pOperacion = frmManPromocionProximaEdit.Operacion.Modificar;
                objManPromocionProximaEdit.IdPromocionProxima = objPromocionProxima.IdPromocionProxima;
                objManPromocionProximaEdit.pPromocionProximaBE = objPromocionProxima;
                objManPromocionProximaEdit.StartPosition = FormStartPosition.CenterParent;
                objManPromocionProximaEdit.ShowDialog();

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

            if (gvPromocionProxima.GetFocusedRowCellValue("IdPromocionProxima").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione PromocionProxima", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}