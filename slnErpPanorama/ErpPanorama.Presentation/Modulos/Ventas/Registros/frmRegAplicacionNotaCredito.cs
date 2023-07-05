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
    public partial class frmRegAplicacionNotaCredito : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PagosBE> mLista = new List<PagosBE>();

        DataTable dt = new DataTable();

        #endregion

        #region "Eventos"

        public frmRegAplicacionNotaCredito()
        {
            InitializeComponent();
        }

        private void frmRegAplicacionNotaCredito_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            cboTienda.EditValue = Parametros.intTiendaId;
            cboCaja.EditValue = Parametros.intCajaId;
            //BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescCaja", "IdCaja", true);
            //
            deFecha.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegAplicacionNotaCreditoEdit objManReciboPago = new frmRegAplicacionNotaCreditoEdit();
                objManReciboPago.lstPago = new PagosBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue),Convert.ToDateTime(deFecha.EditValue), Parametros.intTipoDocTicketAgenteBanco);
                objManReciboPago.pOperacion = frmRegAplicacionNotaCreditoEdit.Operacion.Nuevo;
                objManReciboPago.IdPago = 0;
                objManReciboPago.FechaD = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objManReciboPago.StartPosition = FormStartPosition.CenterParent;
                objManReciboPago.ShowDialog();
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
                        //Datos del Recibo de Pago
                        PagosBE objE_Pagos = new PagosBE();
                        objE_Pagos.IdPago = int.Parse(gvReciboPago.GetFocusedRowCellValue("IdPago").ToString());
                        objE_Pagos.Usuario = Parametros.strUsuarioLogin;
                        objE_Pagos.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Pagos.IdEmpresa = int.Parse(gvReciboPago.GetFocusedRowCellValue("IdEmpresa").ToString());

                        //Datos del Movimiento de Caja
                        MovimientoCajaBE objE_MovimientoCaja = null;
                        objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(objE_Pagos.IdEmpresa, int.Parse(gvReciboPago.GetFocusedRowCellValue("IdTipoDocumento").ToString()), gvReciboPago.GetFocusedRowCellValue("NumeroDocumento").ToString());

                        PagosBL objBL_Pagos = new PagosBL();
                        objBL_Pagos.Elimina(objE_Pagos, objE_MovimientoCaja);
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

        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoReciboPago";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvReciboPago.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvReciboPago_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void cboCaja_EditValueChanged(object sender, EventArgs e)
        {
            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }

        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            dt = FuncionBase.ToDataTable(new PagosBL().ListaNotaCredito(Parametros.intEmpresaId, Convert.ToInt32(cboCaja.EditValue)));
            gcReciboPago.DataSource = dt;
        }

        public void InicializarModificar()
        {
            if (gvReciboPago.RowCount > 0)
            {
                PagosBE objReciboPago = new PagosBE();
                objReciboPago.IdPago = int.Parse(gvReciboPago.GetFocusedRowCellValue("IdPago").ToString());
                objReciboPago.Fecha = DateTime.Parse(gvReciboPago.GetFocusedRowCellValue("Fecha").ToString());

                frmRegAplicacionNotaCreditoEdit objRegReciboPagoEdit = new frmRegAplicacionNotaCreditoEdit();
                objRegReciboPagoEdit.pOperacion = frmRegAplicacionNotaCreditoEdit.Operacion.Modificar;
                objRegReciboPagoEdit.IdPago = objReciboPago.IdPago;
                objRegReciboPagoEdit.FechaD = objReciboPago.Fecha;
                objRegReciboPagoEdit.StartPosition = FormStartPosition.CenterParent;
                objRegReciboPagoEdit.ShowDialog();

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

            if (gvReciboPago.GetFocusedRowCellValue("IdPago").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void ValidarCierre()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<CajaCierreBE> Obj_CajaCierre = new List<CajaCierreBE>();
                Obj_CajaCierre = new CajaCierreBL().ListaFechaCaja(Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToInt32(cboCaja.EditValue));

                if (Obj_CajaCierre.Count > 0)
                {
                    XtraMessageBox.Show("La Caja está Cerrada!, no se puede modificar, Consulte con su administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DesHabilitarBotones();
                }
                else
                {
                    HabilitarBotones();
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

        private void HabilitarBotones()
        {
            tlbMenu.Enabled = true;
            gcReciboPago.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            tlbMenu.Enabled = false;
            gcReciboPago.Enabled = false;
        }

        #endregion

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
        }
    }
}