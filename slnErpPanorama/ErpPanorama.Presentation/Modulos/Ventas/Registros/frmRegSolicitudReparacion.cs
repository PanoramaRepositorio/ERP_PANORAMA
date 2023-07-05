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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegSolicitudReparacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CambioBE> mLista = new List<CambioBE>();

        #endregion

        #region "Eventos"

        public frmRegSolicitudReparacion()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudReparacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            cboMes.EditValue = DateTime.Now.Month;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegSolicitudReparacionEdit objManCambio = new frmRegSolicitudReparacionEdit();
                objManCambio.lstCambio = mLista;
                objManCambio.pOperacion = frmRegSolicitudReparacionEdit.Operacion.Nuevo;
                objManCambio.IdCambio = 0;
                objManCambio.StartPosition = FormStartPosition.CenterParent;
                objManCambio.ShowDialog();
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
                        CambioBE objE_Cambio = (CambioBE)gvCambio.GetRow(gvCambio.FocusedRowHandle);
                        objE_Cambio.Usuario = Parametros.strUsuarioLogin;
                        objE_Cambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Cambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());

                        CambioBL objBL_Cambio = new CambioBL();
                        objBL_Cambio.Elimina(objE_Cambio);
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
                    List<ReporteCambioBE> lstReporte = null;
                    lstReporte = new ReporteCambioBL().Listado(int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString()));

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptCambio = new RptVistaReportes();
                            objRptCambio.VerRptCambioReparacion(lstReporte);
                            objRptCambio.ShowDialog();
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
            string _fileName = "ListadoCambios";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCambio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCambio_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }


        private void anulardevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CambioBL().ListaTodosActivoReparacion(0, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));
            gcCambio.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCambio.DataSource = mLista.Where(obj =>
                                                   obj.Numero.ToUpper().Contains(txtNumero.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCambio.RowCount > 0)
            {
                CambioBE objCambio = new CambioBE();
                objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());

                frmRegSolicitudReparacionEdit objManCambiolEdit = new frmRegSolicitudReparacionEdit();
                objManCambiolEdit.pOperacion = frmRegSolicitudReparacionEdit.Operacion.Modificar;
                objManCambiolEdit.IdCambio = objCambio.IdCambio;
                objManCambiolEdit.IdEmpresa = objCambio.IdEmpresa;
                objManCambiolEdit.StartPosition = FormStartPosition.CenterParent;
                objManCambiolEdit.btnGrabar.Enabled = true;
                objManCambiolEdit.ShowDialog();

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

            if (gvCambio.GetFocusedRowCellValue("IdCambio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void recibirdevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "yosorio" || Parametros.strUsuarioLogin == "jrodriguez" || Parametros.strUsuarioLogin == "jvasquez" )
                    {
                        bool flagRecibido = true;
                        flagRecibido = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagRecibido").ToString());
                        if (!flagRecibido)
                        {
                            CambioBE objCambio = new CambioBE();
                            objCambio.IdTipoDocumento = int.Parse(gvCambio.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                            objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                            objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                            objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                            objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                            objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                            objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                            objCambio.Usuario = Parametros.strUsuarioLogin;
                            objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            List<CambioDetalleBE> mListaCambioDetalle = null;
                            mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);

                            CambioBL objBL_Cambio = new CambioBL();
                            objBL_Cambio.ActualizaRecibido(objCambio, mListaCambioDetalle);

                            XtraMessageBox.Show("La solicitud de devolución se recibió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                            Cursor = Cursors.Default;
                            
                        }
                        else
                        {
                            XtraMessageBox.Show("La solicitud de devolución esta recibida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                    }

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