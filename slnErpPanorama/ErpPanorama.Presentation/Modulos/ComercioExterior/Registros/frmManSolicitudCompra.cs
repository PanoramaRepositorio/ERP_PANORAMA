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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmManSolicitudCompra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<SolicitudCompraBE> mLista = new List<SolicitudCompraBE>();

        #endregion

        #region "Eventos"

        public frmManSolicitudCompra()
        {
            InitializeComponent();
        }

        private void frmManSolicitudCompra_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManSolicitudCompraEdit objManSolicitudCompra = new frmManSolicitudCompraEdit();
                objManSolicitudCompra.pOperacion = frmManSolicitudCompraEdit.Operacion.Nuevo;
                objManSolicitudCompra.IdSolicitudCompra = 0;
                objManSolicitudCompra.StartPosition = FormStartPosition.CenterParent;
                objManSolicitudCompra.ShowDialog();
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

                if (gvSolicitudCompra.RowCount > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "marjorie" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "etapia" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ygomez")
                        {
                            if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                if (!ValidarIngreso())
                                {
                                    SolicitudCompraBE objE_SolicitudCompra = new SolicitudCompraBE();
                                    objE_SolicitudCompra.IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());
                                    objE_SolicitudCompra.Usuario = Parametros.strUsuarioLogin;
                                    objE_SolicitudCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                    objE_SolicitudCompra.IdEmpresa = Parametros.intEmpresaId;

                                    SolicitudCompraBL objBL_SolicitudCompra = new SolicitudCompraBL();
                                    objBL_SolicitudCompra.Elimina(objE_SolicitudCompra);
                                    XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Cargar();
                                }
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }


                //if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    if (!ValidarIngreso())
                //    {
                //        SolicitudCompraBE objE_SolicitudCompra = new SolicitudCompraBE();
                //        objE_SolicitudCompra.IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());
                //        objE_SolicitudCompra.Usuario = Parametros.strUsuarioLogin;
                //        objE_SolicitudCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                //        objE_SolicitudCompra.IdEmpresa = Parametros.intEmpresaId;

                //        SolicitudCompraBL objBL_SolicitudCompra = new SolicitudCompraBL();
                //        objBL_SolicitudCompra.Elimina(objE_SolicitudCompra);
                //        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        Cargar();
                //    }
                //}
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
            //    if (mLista.Count > 0)
            //    {
            //        SolicitudCompraBE objE_SolicitudCompra = new SolicitudCompraBE();
            //        objE_SolicitudCompra.IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());
            //        objE_SolicitudCompra.IdEmpresa = Parametros.intEmpresaId;

            //        List<ReporteSolicitudCompraBE> lstReporte = null;
            //        lstReporte = new ReporteSolicitudCompraBL().Listado(Parametros.intEmpresaId, objE_SolicitudCompra.IdSolicitudCompra);

            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptSolicitudCompra = new RptVistaReportes();
            //                objRptSolicitudCompra.VerRptSolicitudCompra(lstReporte);
            //                objRptSolicitudCompra.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }

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
            string _fileName = "ListadoSolicitudCompras";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSolicitudCompra.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSolicitudCompra_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            Cargar();
        }

        private void actualizafecharecepcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                frmRegActualizaFechaRecepcion objSolicitudCompra = new frmRegActualizaFechaRecepcion();
                objSolicitudCompra.Origen = 1;
                objSolicitudCompra.IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());
                if (objSolicitudCompra.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }

                Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vercatalogotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvSolicitudCompra.RowCount > 0)
                {
                    int IdSolicitudCompra = 0;
                    IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());

                    List<ReporteProductoCatalogoFacturaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoFacturaBL().ListadoSolicitudCompra(Parametros.intEmpresaId, IdSolicitudCompra, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoFactura = new RptVistaReportes();
                            objRptProductoCatalogoFactura.VerRptProductoCatalogoFactura(lstReporte);
                            objRptProductoCatalogoFactura.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vercatalogosolestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvSolicitudCompra.RowCount > 0)
                {
                    int IdSolicitudCompra = 0;
                    IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());

                    List<ReporteProductoCatalogoFacturaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoFacturaBL().ListadoSolicitudCompra(Parametros.intEmpresaId, IdSolicitudCompra, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoFactura = new RptVistaReportes();
                            objRptProductoCatalogoFactura.VerRptProductoCatalogoFacturaSoles(lstReporte);
                            objRptProductoCatalogoFactura.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new SolicitudCompraBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intPeriodo);
            gcSolicitudCompra.DataSource = mLista;

            CalcularTotalDocumentos();
        }

        private void CargarBusqueda()
        {
            gcSolicitudCompra.DataSource = mLista.Where(obj =>
                                                   obj.NumeroDocumento.ToUpper().Contains(txtNumeroDocumento.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvSolicitudCompra.RowCount > 0)
            {
                SolicitudCompraBE objSolicitudCompra = new SolicitudCompraBE();
                objSolicitudCompra.IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());

                frmManSolicitudCompraEdit objManSolicitudCompraEdit = new frmManSolicitudCompraEdit();
                objManSolicitudCompraEdit.pOperacion = frmManSolicitudCompraEdit.Operacion.Modificar;
                objManSolicitudCompraEdit.IdSolicitudCompra = objSolicitudCompra.IdSolicitudCompra;
                objManSolicitudCompraEdit.StartPosition = FormStartPosition.CenterParent;
                objManSolicitudCompraEdit.ShowDialog();

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

            if (gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Factura Compra", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void verclasificacionpreciofototoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaProductoFoto frm = new frmListaProductoFoto();
            frm.IdSolicitudCompra = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdSolicitudCompra").ToString());
            frm.Show();
        }

        private void generarfacuracompratoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManFacturaCompraSolicitudCompraEdit objManFacturaCompra = new frmManFacturaCompraSolicitudCompraEdit();
                objManFacturaCompra.pOperacion = frmManFacturaCompraSolicitudCompraEdit.Operacion.Nuevo;
                objManFacturaCompra.IdFacturaCompra = 0;
                objManFacturaCompra.IdProveedor = int.Parse(gvSolicitudCompra.GetFocusedRowCellValue("IdProveedor").ToString());
                objManFacturaCompra.NumeroSolicitudCompra = gvSolicitudCompra.GetFocusedRowCellValue("NumeroDocumento").ToString();
                objManFacturaCompra.StartPosition = FormStartPosition.CenterParent;
                objManFacturaCompra.ShowDialog();
                //if (objManFacturaCompra.ShowDialog() == DialogResult.OK)
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;
                int intCantidad = 0;
                int intItems = 0;

                for (int i = 0; i < gvSolicitudCompra.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvSolicitudCompra.GetRowCellValue(i, (gvSolicitudCompra.Columns["Importe"])));
                    intCantidad = intCantidad + Convert.ToInt32(gvSolicitudCompra.GetRowCellValue(i, (gvSolicitudCompra.Columns["Cantidad"])));
                    intItems = intItems + Convert.ToInt32(gvSolicitudCompra.GetRowCellValue(i, (gvSolicitudCompra.Columns["Items"])));

                }
                txtTotal.EditValue = decTotal;
                txtTotalCantidad.EditValue = intCantidad;
                txtTotalItems.EditValue = intItems;

                lblTotalRegistros.Text = gvSolicitudCompra.RowCount.ToString() + " Registros";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvSolicitudCompra_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }


    }
}