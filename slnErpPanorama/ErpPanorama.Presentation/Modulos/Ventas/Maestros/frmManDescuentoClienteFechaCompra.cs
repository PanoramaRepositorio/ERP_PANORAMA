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
    public partial class frmManDescuentoClienteFechaCompra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<DescuentoClienteFechaCompraBE> mLista = new List<DescuentoClienteFechaCompraBE>();

        public ParametroBE pParametroBE;

        #endregion

        #region "Eventos"

        public frmManDescuentoClienteFechaCompra()
        {
            InitializeComponent();
        }

        private void frmManDescuentoClienteFechaCompra_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            CargarEstado();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManDescuentoClienteFechaCompraEdit objManDescuentoClienteFechaCompra = new frmManDescuentoClienteFechaCompraEdit();
                objManDescuentoClienteFechaCompra.lstDescuentoClienteFechaCompra = mLista;
                objManDescuentoClienteFechaCompra.pOperacion = frmManDescuentoClienteFechaCompraEdit.Operacion.Nuevo;
                objManDescuentoClienteFechaCompra.IdDescuentoClienteFechaCompra = 0;
                objManDescuentoClienteFechaCompra.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClienteFechaCompra.ShowDialog();
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
                        DescuentoClienteFechaCompraBE objE_DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBE();
                        objE_DescuentoClienteFechaCompra.IdDescuentoClienteFechaCompra = int.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("IdDescuentoClienteFechaCompra").ToString());
                        objE_DescuentoClienteFechaCompra.Usuario = Parametros.strUsuarioLogin;
                        objE_DescuentoClienteFechaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_DescuentoClienteFechaCompra.IdEmpresa = Parametros.intEmpresaId;

                        DescuentoClienteFechaCompraBL objBL_DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBL();
                        objBL_DescuentoClienteFechaCompra.Elimina(objE_DescuentoClienteFechaCompra);
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

            //    List<ErpPanoramaServicios.ReporteDescuentoClienteFechaCompraBE> lstReporte = null;
            //    lstReporte = objServicio.ReporteDescuentoClienteFechaCompra_Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptDescuentoClienteFechaCompra = new RptVistaReportes();
            //            objRptDescuentoClienteFechaCompra.VerRptDescuentoClienteFechaCompra(lstReporte);
            //            objRptDescuentoClienteFechaCompra.ShowDialog();
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
            string _fileName = "ListadoDescuentoClienteFechaCompras";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDescuentoClienteFechaCompra.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDescuentoClienteFechaCompra_DoubleClick(object sender, EventArgs e)
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

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
                ParametroBL objBL_Campana = new ParametroBL();
                if (chkEstado.Checked == true)
                {
                    pParametroBE.FlagEstado = true;
                    objBL_Campana.Actualiza(pParametroBE);
                    chkEstado.Text = "Habilitado";
                    //XtraMessageBox.Show("Se Habilitó el descuento Según estos Rangos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    pParametroBE.FlagEstado = false;
                    objBL_Campana.Actualiza(pParametroBE);
                    chkEstado.Text = "DesHabilitado";
                    //XtraMessageBox.Show("Se Deshabilitó el descuento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }               
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DescuentoClienteFechaCompraBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDescuentoClienteFechaCompra.DataSource = mLista;
        }

        private void CargarEstado()
        {
            pParametroBE = new ParametroBL().Selecciona(Parametros.strDescuentoClienteFechaCompra);
            chkEstado.Checked = pParametroBE.FlagEstado;
        }

        public void InicializarModificar()
        {
            if (gvDescuentoClienteFechaCompra.RowCount > 0)
            {
                DescuentoClienteFechaCompraBE objDescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBE();
                objDescuentoClienteFechaCompra.IdDescuentoClienteFechaCompra = int.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("IdDescuentoClienteFechaCompra").ToString());
                objDescuentoClienteFechaCompra.IdTipoCliente = int.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("IdTipoCliente").ToString());
                objDescuentoClienteFechaCompra.IdFormaPago = int.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("IdFormaPago").ToString());
                objDescuentoClienteFechaCompra.IdLineaProducto = int.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("IdLineaProducto").ToString());
                objDescuentoClienteFechaCompra.FechaInicio = DateTime.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("FechaInicio").ToString());
                objDescuentoClienteFechaCompra.FechaFin = DateTime.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("FechaFin").ToString());
                objDescuentoClienteFechaCompra.Descuento = decimal.Parse(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("Descuento").ToString());
                objDescuentoClienteFechaCompra.FlagEstado = Convert.ToBoolean(gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManDescuentoClienteFechaCompraEdit objManDescuentoClienteFechaCompraEdit = new frmManDescuentoClienteFechaCompraEdit();
                objManDescuentoClienteFechaCompraEdit.pOperacion = frmManDescuentoClienteFechaCompraEdit.Operacion.Modificar;
                objManDescuentoClienteFechaCompraEdit.IdDescuentoClienteFechaCompra = objDescuentoClienteFechaCompra.IdDescuentoClienteFechaCompra;
                objManDescuentoClienteFechaCompraEdit.pDescuentoClienteFechaCompraBE = objDescuentoClienteFechaCompra;
                objManDescuentoClienteFechaCompraEdit.StartPosition = FormStartPosition.CenterParent;
                objManDescuentoClienteFechaCompraEdit.ShowDialog();

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

            if (gvDescuentoClienteFechaCompra.GetFocusedRowCellValue("IdDescuentoClienteFechaCompra").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione DescuentoClienteFechaCompra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CargarBusqueda()
        {
            gcDescuentoClienteFechaCompra.DataSource = mLista.Where(obj =>
                                                   obj.DescLineaProducto.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        #endregion



    }
}