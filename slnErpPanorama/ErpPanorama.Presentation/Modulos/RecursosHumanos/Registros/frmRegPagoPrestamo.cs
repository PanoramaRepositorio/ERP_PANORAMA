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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPagoPrestamo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SolicitudPrestamoBE> mLista = new List<SolicitudPrestamoBE>();

        #endregion

        #region "Eventos"

        public frmRegPagoPrestamo()
        {
            InitializeComponent();
        }

        private void frmRegPagoPrestamo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = Convert.ToDateTime("01/" + DateTime.Now.Month + "/" + Parametros.intPeriodo);
            deFechaHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegPagoPrestamoEdit objManSolicitudPrestamo = new frmRegPagoPrestamoEdit();
                //objManSolicitudPrestamo.lstSolicitudPrestamo = mLista;
                objManSolicitudPrestamo.pOperacion = frmRegPagoPrestamoEdit.Operacion.Nuevo;
                objManSolicitudPrestamo.IdSolicitudPrestamo = 0;
                objManSolicitudPrestamo.StartPosition = FormStartPosition.CenterParent;
                objManSolicitudPrestamo.ShowDialog();
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
                        //string NumeroEgreso = "";
                        SolicitudPrestamoBE objE_SolicitudPrestamo = new SolicitudPrestamoBE();
                        objE_SolicitudPrestamo.IdSolicitudPrestamo = int.Parse(gvSolicitudPrestamo.GetFocusedRowCellValue("IdSolicitudPrestamo").ToString());

                        //NumeroEgreso = gvSolicitudPrestamo.GetFocusedRowCellValue("NumeroEgreso").ToString();
                        //if (NumeroEgreso.Length > 0)
                        //{
                        //    XtraMessageBox.Show("No se puede eliminar, el préstamo tiene asociado un pago.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //    return;
                        //}

                        objE_SolicitudPrestamo.Usuario = Parametros.strUsuarioLogin;
                        objE_SolicitudPrestamo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_SolicitudPrestamo.IdEmpresa = Parametros.intEmpresaId;

                        SolicitudPrestamoBL objBL_SolicitudPrestamo = new SolicitudPrestamoBL();
                        objBL_SolicitudPrestamo.Elimina(objE_SolicitudPrestamo);
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

                int IdSolicitudPrestamo = 0;
                IdSolicitudPrestamo = int.Parse(gvSolicitudPrestamo.GetFocusedRowCellValue("IdSolicitudPrestamo").ToString());

                List<ReporteSolicitudPrestamoBE> lstReporte = null;
                lstReporte = new ReporteSolicitudPrestamoBL().Listado(Parametros.intEmpresaId, IdSolicitudPrestamo);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptSolicitudPrestamo = new RptVistaReportes();
                        objRptSolicitudPrestamo.VerRptSolicitudPrestamoPago(lstReporte);
                        objRptSolicitudPrestamo.ShowDialog();
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
            string _fileName = "ListadoSolicitudPrestamo";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSolicitudPrestamo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSolicitudPrestamo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtApeNom_EditValueChanged(object sender, EventArgs e)
        {
            //CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
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
            mLista = new SolicitudPrestamoBL().ListaFecha(Parametros.intEmpresaId, Parametros.intTipoDocReciboDescuentoPlanilla, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));
            gcSolicitudPrestamo.DataSource = mLista;

            CalcularTotalDocumentos();
            lblTotalRegistros.Text = gvSolicitudPrestamo.RowCount.ToString() + " Registros";
        }

        //private void CargarBusqueda()
        //{
        //    gcSolicitudPrestamo.DataSource = mLista.Where(obj =>
        //                                           obj.ApeNom.ToUpper().Contains(txtApeNom.Text.ToUpper())).ToList();
        //}

        public void InicializarModificar()
        {
            if (gvSolicitudPrestamo.RowCount > 0)
            {
                SolicitudPrestamoBE objSolicitudPrestamo = new SolicitudPrestamoBE();
                objSolicitudPrestamo.IdSolicitudPrestamo = int.Parse(gvSolicitudPrestamo.GetFocusedRowCellValue("IdSolicitudPrestamo").ToString());

                frmRegPagoPrestamoEdit objManSolicitudPrestamoEdit = new frmRegPagoPrestamoEdit();
                objManSolicitudPrestamoEdit.pOperacion = frmRegPagoPrestamoEdit.Operacion.Modificar;
                objManSolicitudPrestamoEdit.IdSolicitudPrestamo = objSolicitudPrestamo.IdSolicitudPrestamo;
                objManSolicitudPrestamoEdit.StartPosition = FormStartPosition.CenterParent;
                objManSolicitudPrestamoEdit.ShowDialog();

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

            if (gvSolicitudPrestamo.GetFocusedRowCellValue("IdSolicitudPrestamo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una SolicitudPrestamo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CargarBusqueda()
        {
            gcSolicitudPrestamo.DataSource = mLista.Where(obj => /*obj.Dni.ToUpper().Contains(txtDescripcion.Text.ToUpper()) ||*/
                                                   obj.DescPersona.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvSolicitudPrestamo.RowCount; i++)
                {
                    decTotal = decTotal + Convert.ToDecimal(gvSolicitudPrestamo.GetRowCellValue(i, (gvSolicitudPrestamo.Columns["Importe"])));
                }
                txtTotal.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void imprimirporfechatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteSolicitudPrestamoBE> lstReporte = null;
                lstReporte = new ReporteSolicitudPrestamoBL().ListadoFecha(Parametros.intEmpresaId, Parametros.intTipoDocReciboDescuentoPlanilla, Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deFechaHasta.DateTime.ToShortDateString()));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptSolicitudPrestamo = new RptVistaReportes();
                        objRptSolicitudPrestamo.VerRptSolicitudPrestamoPago(lstReporte);
                        objRptSolicitudPrestamo.ShowDialog();
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

        private void gvSolicitudPrestamo_ColumnFilterChanged(object sender, EventArgs e)
        {
            CalcularTotalDocumentos();
        }


    }
}