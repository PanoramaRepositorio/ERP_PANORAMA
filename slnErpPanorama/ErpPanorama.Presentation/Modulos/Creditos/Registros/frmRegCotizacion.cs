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

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegCotizacion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CotizacionBE> mLista = new List<CotizacionBE>();

        #endregion

        #region "Eventos"

        public frmRegCotizacion()
        {
            InitializeComponent();
        }

        private void frmRegCotizacion_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegCotizacionEdit objManCotizacion = new frmRegCotizacionEdit();
                objManCotizacion.pOperacion = frmRegCotizacionEdit.Operacion.Nuevo;
                //objManCotizacion.lstCotizacion = mLista;
                objManCotizacion.IdCotizacion = 0;
                objManCotizacion.StartPosition = FormStartPosition.CenterParent;
                objManCotizacion.ShowDialog();
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
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            if (frmAutoriza.Usuario == "dhuaman" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "mmurrugarra" || frmAutoriza.Usuario == "ygomez")
                            {
                                CotizacionBE objE_Cotizacion = new CotizacionBE();
                                objE_Cotizacion.IdCotizacion = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdCotizacion").ToString());
                                objE_Cotizacion.IdPedido = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdPedido").ToString());
                                objE_Cotizacion.Usuario = Parametros.strUsuarioLogin;
                                objE_Cotizacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_Cotizacion.IdEmpresa = Parametros.intEmpresaId;

                                CotizacionBL objBL_Cotizacion = new CotizacionBL();
                                objBL_Cotizacion.Elimina(objE_Cotizacion);
                                XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cargar();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
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

                if (gvCotizacion.RowCount > 0)
                {
                    int IdCotizacion = 0;
                    IdCotizacion = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdCotizacion").ToString());

                    List<ReporteCotizacionBE> lstReporte = null;
                    lstReporte = new ReporteCotizacionBL().Listado(Parametros.intEmpresaId, IdCotizacion);

                    if (lstReporte != null)
                    {
                        //Listar el datalle del reporte
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptAccUsu = new RptVistaReportes();
                            objRptAccUsu.VerRptCotizacion(lstReporte, lstReporte);
                            objRptAccUsu.ShowDialog();
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

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoCotizaciones";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCotizacion.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCotizacion_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumeroCotizacion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaPedido();
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CotizacionBL().ListaFecha(Parametros.intEmpresaId,deDesde.DateTime, deHasta.DateTime);
            gcCotizacion.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            mLista = new CotizacionBL().ListaNumero(deDesde.DateTime.Year, txtNumeroCotizacion.Text);
            gcCotizacion.DataSource = mLista;
        }

        private void CargarBusquedaPedido()
        {
            mLista = new CotizacionBL().ListaPedido(deDesde.DateTime.Year, txtNumeroPedido.Text);
            gcCotizacion.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCotizacion.RowCount > 0)
            {
                bool flagEnviado = true;
                flagEnviado = bool.Parse(gvCotizacion.GetFocusedRowCellValue("FlagEnviado").ToString());
                if (flagEnviado)
                {
                    XtraMessageBox.Show("No se puede modificar la solicitud ya fué enviada almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    CotizacionBE objCotizacion = new CotizacionBE();
                    objCotizacion.IdCotizacion = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdCotizacion").ToString());

                    frmRegCotizacionEdit objManCotizacionlEdit = new frmRegCotizacionEdit();
                    objManCotizacionlEdit.pOperacion = frmRegCotizacionEdit.Operacion.Modificar;
                    objManCotizacionlEdit.IdCotizacion = objCotizacion.IdCotizacion;
                    objManCotizacionlEdit.StartPosition = FormStartPosition.CenterParent;
                    objManCotizacionlEdit.btnGrabar.Enabled = false;
                    objManCotizacionlEdit.ShowDialog();

                    Cargar();
                }
                else
                {
                    CotizacionBE objCotizacion = new CotizacionBE();
                    objCotizacion.IdCotizacion = int.Parse(gvCotizacion.GetFocusedRowCellValue("IdCotizacion").ToString());

                    frmRegCotizacionEdit objManCotizacionlEdit = new frmRegCotizacionEdit();
                    objManCotizacionlEdit.pOperacion = frmRegCotizacionEdit.Operacion.Modificar;
                    objManCotizacionlEdit.IdCotizacion = objCotizacion.IdCotizacion;
                    objManCotizacionlEdit.StartPosition = FormStartPosition.CenterParent;
                    objManCotizacionlEdit.btnGrabar.Enabled = true;
                    objManCotizacionlEdit.ShowDialog();

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

            if (gvCotizacion.GetFocusedRowCellValue("IdCotizacion").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

       
        
         
    }
}