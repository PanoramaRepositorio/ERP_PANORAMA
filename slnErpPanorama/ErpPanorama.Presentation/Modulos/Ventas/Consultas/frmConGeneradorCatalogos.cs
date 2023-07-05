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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConGeneradorCatalogos : DevExpress.XtraEditors.XtraForm
    {


        #region "Propiedades"

        public List<ReporteKardexBultoBE> lstProducto;
        private List<ProformaBE> mLista = new List<ProformaBE>();
        #endregion

        #region "Eventos"
        public frmConGeneradorCatalogos()
        {
            InitializeComponent();
        }

        private void frmConGeneradorCatalogos_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            cboLinea.EditValue = Parametros.intNinguno;
            BSUtils.LoaderLook(cboMaterial, new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMaterial", "IdMaterial", true);
            cboMaterial.EditValue = Parametros.intNinguno;
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoCliente.EditValue = Parametros.intTipClienteMayorista;
        }


        private void cboLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboSubLinea, new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString())), "DescSubLineaProducto", "IdSubLineaProducto", false);
                cboSubLinea.EditValue = Parametros.intNinguno;
                //BSUtils.LoaderLook(cboModelo, new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString()), 0), "DescModeloProducto", "IdModeloProducto", false);
                //cboModelo.EditValue = Parametros.intNinguno;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string _msg = "Se genero el archivo pdf de forma satisfactoria en la siguiente ubicación.\n{0}";
                string _fileName = "Catalogo_Lin_" + cboLinea.Text.Trim() + "_Sub_" + cboModelo.Text.Trim() + "_Mat_" + cboMaterial.Text.Trim();
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;
                    if (Convert.ToInt32(cboTipoCliente.EditValue) == Parametros.intTipClienteMayorista)
                    {
                        List<ReporteProductoCatologoInvBultoBE> lstReporteInv = null;
                        lstReporteInv = new ReporteProductoCatologoInvBultoBL().Listado(Parametros.intEmpresaId);
                        rptProductoCatalogoDolares objReporte = new rptProductoCatalogoDolares();
                     //   rptProductoCatalogo objReporte = new rptProductoCatalogo();
                        objReporte.SetDataSource(lstReporteInv);
                        objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, f.SelectedPath + @"\" + _fileName + ".pdf");
                        string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".pdf");
                        XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        List<ReporteProductoCatologoInvBultoBE> lstReporteInv = null;
                        lstReporteInv = new ReporteProductoCatologoInvBultoBL().Listado(Parametros.intEmpresaId);
                        rptProductoCatalogoSoles objReporte = new rptProductoCatalogoSoles();
                        objReporte.SetDataSource(lstReporteInv);
                        objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, f.SelectedPath + @"\" + _fileName + ".pdf");
                        string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".pdf");
                        XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {

        }

        private void btnExportarPDFxLinea_Click(object sender, EventArgs e)
        {
            try
            {
                string _msg = "Se genero el archivo pdf de forma satisfactoria en la siguiente ubicación.\n{0}";
                //string _fileName = "Linea";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    Cursor = Cursors.AppStarting;

                    for (int i = 1; i <= 10; i++)
                    {
                        gcProducto.DataSource = new ReporteKardexBultoBL().KardexBulto_Listado(Parametros.intEmpresaId, i, 0, 0,0);

                        string nomLinea = ""; ;
                        if (gvProducto.RowCount > 0)
                        {
                            nomLinea = gvProducto.GetFocusedRowCellValue("DescLineaProducto").ToString();

                            if (Convert.ToInt32(cboTipoCliente.EditValue) == Parametros.intTipClienteMayorista)
                            {
                                List<ReporteProductoCatologoInvBultoBE> lstReporteaaa = null;
                                lstReporteaaa = new ReporteProductoCatologoInvBultoBL().Listado(13);
                                //   rptProductoCatalogo objReporte = new rptProductoCatalogo();
                                rptProductoCatalogoDolares objReporte = new rptProductoCatalogoDolares();
                                objReporte.SetDataSource(lstReporteaaa);
                                objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, f.SelectedPath + @"\" + Convert.ToString(i) + "." + nomLinea + ".pdf");
                                string _nM = string.Format(_msg, f.SelectedPath + @"\" + Convert.ToString(i) + "." + nomLinea + ".pdf");
                                lblNumExp.Text = _nM;
                            }
                            else
                            {
                                List<ReporteProductoCatologoInvBultoBE> lstReporteaaa = null;
                                lstReporteaaa = new ReporteProductoCatologoInvBultoBL().Listado(13);
                                rptProductoCatalogoSoles objReporte = new rptProductoCatalogoSoles();
                                objReporte.SetDataSource(lstReporteaaa);
                                objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, f.SelectedPath + @"\" + Convert.ToString(i) + "." + nomLinea + ".pdf");
                                string _nM = string.Format(_msg, f.SelectedPath + @"\" + Convert.ToString(i) + "." + nomLinea + ".pdf");
                                lblNumExp.Text = _nM;
                            }
                        }
                    }

                    Cursor = Cursors.Default;
                }

                //---------------------------------------------------------------------


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarNavidadPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.AppStarting;

                string _msg = "Se genero el archivo pdf de forma satisfactoria en la siguiente ubicación.\n{0}";
                //string _fileName = "Linea";
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog(this);
                if (f.SelectedPath != "")
                {
                    if (Convert.ToInt32(cboTipoCliente.EditValue) == Parametros.intTipClienteMayorista)
                    {
                        List<ReporteProductoCatologoInvBultoBE> lstReporteaaa = null;
                        lstReporteaaa = new ReporteProductoCatologoInvBultoBL().ListadoPreNavidad(13);
                //        rptProductoCatalogo objReporte = new rptProductoCatalogo();
                        rptProductoCatalogoDolares objReporte = new rptProductoCatalogoDolares();
                        objReporte.SetDataSource(lstReporteaaa);
                        objReporte.ExportToDisk(ExportFormatType.PortableDocFormat, f.SelectedPath + @"\" + "CatalogoPreVentaNavidad.pdf");
                        string _nM = string.Format(_msg, f.SelectedPath + @"\" + "CatalogoPreVentaNavidad.pdf");
                        lblNumExp.Text = _nM;
                    }
                }

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProductos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gvProducto.DeleteRow(gvProducto.FocusedRowHandle);
            gvProducto.RefreshData();
        }

        private void verfotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvProducto.RowCount > 0)
            {
                frmVerFotoProducto objfrmVerfoto = new frmVerFotoProducto();
                objfrmVerfoto.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
                objfrmVerfoto.Show();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            gcProducto.DataSource = new ReporteKardexBultoBL().KardexBulto_Listado(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue), Convert.ToInt32(cboSubLinea.EditValue), Convert.ToInt32(cboModelo.EditValue), Convert.ToInt32(cboMaterial.EditValue));
        }

        public void InicializarModificar()
        {
            if (gvProducto.RowCount > 0)
            {
                ReporteKardexBultoBE objProducto = new ReporteKardexBultoBE();
                objProducto.IdProducto = int.Parse(gvProducto.GetFocusedRowCellValue("IdProducto").ToString());
                objProducto.CodigoProveedor = gvProducto.GetFocusedRowCellValue("CodigoProveedor").ToString();

                frmManProductoEdit objManProductoEdit = new frmManProductoEdit();
                objManProductoEdit.pOperacion = frmManProductoEdit.Operacion.Modificar;
                objManProductoEdit.IdProducto = objProducto.IdProducto;
                objManProductoEdit.CodigoProveedor = objProducto.CodigoProveedor;
                objManProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManProductoEdit.btnGrabar.Enabled = false;
                objManProductoEdit.ShowDialog();
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

        #endregion

        private void cboModelo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboSubLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSubLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboModelo, new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString()), Convert.ToInt32(cboSubLinea.EditValue.ToString())), "DescModeloProducto", "IdModeloProducto", false);
                cboModelo.EditValue = Parametros.intNinguno;
            }

        }

        

    }
}