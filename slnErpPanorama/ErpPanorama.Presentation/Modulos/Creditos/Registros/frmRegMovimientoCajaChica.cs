using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegMovimientoCajaChica : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoCajaChicaBE> mLista = new List<MovimientoCajaChicaBE>();

        DataTable dt = new DataTable();

        #endregion

        #region "Eventos"
        public frmRegMovimientoCajaChica()
        {
            InitializeComponent();
        }

        private void frmRegMovimientoCajaChica_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFechaDesde.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegMovimientoCajaChicaEdit objManMovimientoCajaChica = new frmRegMovimientoCajaChicaEdit();
                //objManMovimientoCajaChica.lstMovimientoCajaChica = new MovimientoCajaChicaBL().ListaTodosActivo(Convert.ToInt32(cboCajaChica.EditValue), Convert.ToDateTime(deFecha.EditValue));
                objManMovimientoCajaChica.pOperacion = frmRegMovimientoCajaChicaEdit.Operacion.Nuevo;
                objManMovimientoCajaChica.IdMovimientoCajaChica = 0;
                objManMovimientoCajaChica.FechaD = Convert.ToDateTime(deFechaDesde.DateTime.ToShortDateString());
                objManMovimientoCajaChica.StartPosition = FormStartPosition.CenterParent;
                objManMovimientoCajaChica.ShowDialog();
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
                        MovimientoCajaChicaBE objE_MovimientoCajaChica = new MovimientoCajaChicaBE();
                        objE_MovimientoCajaChica.IdMovimientoCajaChica = int.Parse(gvMovimientoCajaChica.GetFocusedRowCellValue("IdMovimientoCajaChica").ToString());
                        objE_MovimientoCajaChica.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCajaChica.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCajaChica.IdEmpresa = Parametros.intEmpresaId;

                        MovimientoCajaChicaBL objBL_MovimientoCajaChica = new MovimientoCajaChicaBL();
                        objBL_MovimientoCajaChica.Elimina(objE_MovimientoCajaChica);
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

            //    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rcastañeda")
            //    {
            //        List<ReporteMovimientoCajaBE> lstReporte = null;
            //        lstReporte = new ReporteMovimientoCajaBL().ListadoDocumento(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboCajaChica.EditValue), Convert.ToDateTime(deFechaDesde.EditValue));
            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                List<ReporteMovimientoCajaBE> lstReporteTarjeta = null;
            //                lstReporteTarjeta = new ReporteMovimientoCajaBL().ListadoTarjeta(0, Convert.ToInt32(cboCajaChica.EditValue), Convert.ToDateTime(deFechaDesde.EditValue));

            //                RptVistaReportes objRptMovimientoCaja = new RptVistaReportes();
            //                objRptMovimientoCaja.VerRptMovimientoCajaTarjetaDocumento(lstReporte, lstReporteTarjeta);
            //                objRptMovimientoCaja.ShowDialog();
            //            }
            //            else
            //                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //    }
            //    else
            //    {
            //        List<ReporteMovimientoCajaBE> lstReporte = null;
            //        lstReporte = new ReporteMovimientoCajaBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboCajaChica.EditValue), Convert.ToDateTime(deFechaDesde.EditValue));

            //        if (lstReporte != null)
            //        {
            //            if (lstReporte.Count > 0)
            //            {
            //                RptVistaReportes objRptMovimientoCaja = new RptVistaReportes();
            //                objRptMovimientoCaja.VerRptMovimientoCaja(lstReporte);
            //                objRptMovimientoCaja.ShowDialog();
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
            string _fileName = "ListadoMovimientoCaja";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoCajaChica.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMovimientoCajaChica_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MovimientoCajaChicaBL().ListaFecha(Parametros.intEmpresaId, Convert.ToDateTime(deFechaDesde.EditValue), Convert.ToDateTime(deFechaHasta.EditValue));
            dt = FuncionBase.ToDataTable(mLista);
            gcMovimientoCajaChica.DataSource = dt;
            CalcularTotalDocumentos();
        }

        public void InicializarModificar()
        {
            if (gvMovimientoCajaChica.RowCount > 0)
            {
                MovimientoCajaChicaBE objMovimientoCajaChica = new MovimientoCajaChicaBE();
                objMovimientoCajaChica.IdMovimientoCajaChica = int.Parse(gvMovimientoCajaChica.GetFocusedRowCellValue("IdMovimientoCajaChica").ToString());
                objMovimientoCajaChica.Fecha = DateTime.Parse(gvMovimientoCajaChica.GetFocusedRowCellValue("Fecha").ToString());
                //objMovimientoCajaChica.IdDocumentoVenta = int.Parse(gvMovimientoCajaChicaChica.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                //objMovimientoCajaChica.NumeroCondicion = gvMovimientoCajaChicaChica.GetFocusedRowCellValue("NumeroCondicion").ToString();

                frmRegMovimientoCajaChicaEdit objRegMovimientoCajaChicaEdit = new frmRegMovimientoCajaChicaEdit();
                objRegMovimientoCajaChicaEdit.pOperacion = frmRegMovimientoCajaChicaEdit.Operacion.Modificar;
                objRegMovimientoCajaChicaEdit.IdMovimientoCajaChica = objMovimientoCajaChica.IdMovimientoCajaChica;
                //objRegMovimientoCajaChicaEdit.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                //objRegMovimientoCajaChicaEdit.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                //objRegMovimientoCajaChicaEdit.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                objRegMovimientoCajaChicaEdit.FechaD = objMovimientoCajaChica.Fecha;
                //objRegMovimientoCajaChicaEdit.IdDocumentoVenta = objMovimientoCajaChica.IdDocumentoVenta;
                objRegMovimientoCajaChicaEdit.StartPosition = FormStartPosition.CenterParent;
                if (objRegMovimientoCajaChicaEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }


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

            if (gvMovimientoCajaChica.GetFocusedRowCellValue("IdMovimientoCaja").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvMovimientoCajaChica.RowCount; i++)
                {
                    string Tipo;
                    Tipo = gvMovimientoCajaChica.GetRowCellValue(i, (gvMovimientoCajaChica.Columns["TipoMovimiento"])).ToString();

                    if(Tipo == "S")
                        decTotal = decTotal - Convert.ToDecimal(gvMovimientoCajaChica.GetRowCellValue(i, (gvMovimientoCajaChica.Columns["Importe"])));
                    else
                        decTotal = decTotal + Convert.ToDecimal(gvMovimientoCajaChica.GetRowCellValue(i, (gvMovimientoCajaChica.Columns["Importe"])));

                }
                txtTotal.EditValue = decTotal;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}