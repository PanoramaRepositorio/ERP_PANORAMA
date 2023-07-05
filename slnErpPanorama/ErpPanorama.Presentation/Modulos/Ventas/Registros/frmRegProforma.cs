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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegProforma : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<ProformaBE> mLista = new List<ProformaBE>();
        
        #endregion

        #region "Eventos"

        public frmRegProforma()
        {
            InitializeComponent();
        }

        private void frmRegProforma_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = DateTime.Now.Year;
            cboMes.EditValue = DateTime.Now.Month;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegProformaEdit objManProforma = new frmRegProformaEdit();
                objManProforma.pOperacion = frmRegProformaEdit.Operacion.Nuevo;
                objManProforma.IdProforma = 0;
                objManProforma.StartPosition = FormStartPosition.CenterParent;
                objManProforma.ShowDialog();
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
                        ProformaBE objE_Proforma = new ProformaBE();
                        objE_Proforma.IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());
                        objE_Proforma.Usuario = Parametros.strUsuarioLogin;
                        objE_Proforma.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Proforma.IdEmpresa = Parametros.intEmpresaId;

                        ProformaBL objBL_Proforma = new ProformaBL();
                        objBL_Proforma.Elimina(objE_Proforma);
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
                if (mLista.Count > 0)
                {
                    List<ReporteProformaBE> lstReporte = null;
                    lstReporte = new ReporteProformaBL().Listado(int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProforma = new RptVistaReportes();
                            objRptProforma.VerRptProformaVenta(lstReporte);
                            objRptProforma.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoProforma";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProforma.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProforma_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void cboMes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboMes.EditValue != null)
            {
                Cargar();
            }
        }

        private void txtDescCliente_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusquedaCliente();
        }

        private void txtNumeroProforma_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusquedaNumero();
        }

        private void VerCatalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProforma(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void VerCatalogosinPreciotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProformasinPrecio(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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
            mLista = new ProformaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));
            gcProforma.DataSource = mLista;
        }

        private void CargarBusquedaCliente()
        {
            
            gcProforma.DataSource = mLista.Where(obj =>
                                                   obj.DescCliente.ToUpper().Contains(txtDescCliente.Text.ToUpper())
                                             ).ToList();
        }

        private void CargarBusquedaNumero()
        {
            gcProforma.DataSource = mLista.Where(obj =>
                                                   obj.Numero.ToUpper().Contains(txtNumeroProforma.Text.ToUpper())
                                             ).ToList();
        }

        public void InicializarModificar()
        {
            if (gvProforma.RowCount > 0)
            {
                ProformaBE objProforma = new ProformaBE();
                objProforma.IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                frmRegProformaEdit objRegProformaEdit = new frmRegProformaEdit();
                objRegProformaEdit.pOperacion = frmRegProformaEdit.Operacion.Modificar;
                objRegProformaEdit.IdProforma = objProforma.IdProforma;
                objRegProformaEdit.StartPosition = FormStartPosition.CenterParent;
                objRegProformaEdit.ShowDialog();

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

            if (gvProforma.GetFocusedRowCellValue("IdProforma").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void vercatalogoconprecioabcdtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProformaPrecioABCD(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void vercatalogoconprecioabtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProformaPrecioAB(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void vercatalogoconpreciocdtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProformaPrecioCD(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void verCatalogoConPrecioABHangtagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProformaPrecioABHangtag(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void precioCDsinLogotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProformaPrecioCDSinLogo(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void vercatalogosinpreciosinlogotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.VerRptProductoCatalogoProformaSinPrecioSinLogo(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void verCatalogosinprocedenciatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.rptProductoCatalogosProformaSinProcedencia(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void toolStripMenuItemvercatalogoprofcantidad_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;
            //    if (gvProforma.RowCount > 0)
            //    {
            //        int IdProforma = 0;
            //        IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

            //        List<ReporteProductoCatalogoProformaBE> lstReporte = null;
            //        lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
            //                objRptProductoCatalogoProforma.rptProductoCatalogosProformaCantidad(lstReporte);
            //                objRptProductoCatalogoProforma.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //        Cursor = Cursors.Default;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void mayoristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteMayorista);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.rptProductoCatalogosProformaCantidadAB(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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

        private void finalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvProforma.RowCount > 0)
                {
                    int IdProforma = 0;
                    IdProforma = int.Parse(gvProforma.GetFocusedRowCellValue("IdProforma").ToString());

                    List<ReporteProductoCatalogoProformaBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoProformaBL().Listado(Parametros.intEmpresaId, IdProforma, Parametros.intTipClienteFinal);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoProforma = new RptVistaReportes();
                            objRptProductoCatalogoProforma.rptProductoCatalogosProformaCantidadCD(lstReporte);
                            objRptProductoCatalogoProforma.ShowDialog();
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
    }
}