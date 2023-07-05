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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegInmueblePago : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<InmueblePagoBE> mLista = new List<InmueblePagoBE>();

        int IdCliente = 0;

        #endregion

        #region "Eventos"

        public frmRegInmueblePago()
        {
            InitializeComponent();
        }

        private void frmRegInmueblePago_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            //txtPeriodo.EditValue = DateTime.Now.Year;


            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        
        private void tlbMenu_NewClick()
        {
            try
            {
                if (cboInmueble.Text == "")
                {
                    XtraMessageBox.Show("No se puede agregar nuevo registro falta Inmueble", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                frmRegInmueblePagoEdit objManInmueblePago = new frmRegInmueblePagoEdit();
                objManInmueblePago.lstInmueblePago = mLista;
                objManInmueblePago.pOperacion = frmRegInmueblePagoEdit.Operacion.Nuevo;
                objManInmueblePago.IdCliente = IdCliente;
                objManInmueblePago.IdInmueble = Convert.ToInt32(cboInmueble.EditValue);
                objManInmueblePago.TipoRegistro = "I";
                objManInmueblePago.IdInmueblePago = 0;
                objManInmueblePago.StartPosition = FormStartPosition.CenterParent;
                objManInmueblePago.ShowDialog();
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
                        InmueblePagoBE objE_InmueblePago = new InmueblePagoBE();
                        objE_InmueblePago.IdInmueblePago = int.Parse(gvInmueblePago.GetFocusedRowCellValue("IdInmueblePago").ToString());
                        objE_InmueblePago.IdEmpresa = Parametros.intEmpresaId;
                        objE_InmueblePago.Usuario = Parametros.strUsuarioLogin;
                        objE_InmueblePago.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        InmueblePagoBL objBL_InmueblePago = new InmueblePagoBL();
                        objBL_InmueblePago.Elimina(objE_InmueblePago);
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

            //    List<ReporteInmueblePagoBE> lstReporte = null;
            //    lstReporte = new ReporteInmueblePagoBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboMotivo.EditValue));

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptInmueblePago = new RptVistaReportes();
            //            objRptInmueblePago.VerRptInmueblePago(lstReporte);
            //            objRptInmueblePago.ShowDialog();
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
            string _fileName = "ListadoInmueblePagoles";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInmueblePago.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvInmueblePago_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        //private void txtInmueblePago_EditValueChanged(object sender, EventArgs e)
        //{
        //    CargarBusquedaDocumento();
        //}

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        //private void txtNumeroInmueblePago_KeyUp(object sender, KeyEventArgs e)
        //{
        //    CargarBusquedaDocumento();
        //}


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InmueblePagoBL().ListaClienteInmueble(deDesde.DateTime, deHasta.DateTime,Convert.ToInt32(cboInmueble.EditValue),IdCliente);
            gcInmueblePago.DataSource = mLista;

            if (mLista.Count > 0)
            {
                decimal decTotalCargo = 0;
                decimal decTotalAbono = 0;
                decimal decSaldo = 0;

                foreach (var item in mLista)
                {
                    decTotalCargo = decTotalCargo + item.CreditoCargo;
                    decTotalAbono = decTotalAbono + item.PagoAbono;
                }

                txtTotalCargo.EditValue = decTotalCargo;
                txtTotalAbono.EditValue = decTotalAbono;
                decSaldo = decTotalCargo - decTotalAbono;
                txtSaldo.EditValue = decSaldo;
            }

        }

        private void CargarInmueble()
        {
            BSUtils.LoaderLook(cboInmueble, new InmuebleAlquilerBL().ListaInmuebleCliente(IdCliente), "DescInmueble", "IdInmueble", true);
        }

        //private void CargarBusquedaDocumento()
        //{
        //    gcInmueblePago.DataSource = mLista.Where(obj =>
        //                                           obj.NumeroDocumento.ToString().Contains(txtNumeroInmueblePago.Text.ToUpper())).ToList();


        //}

        public void InicializarModificar()
        {
            if (gvInmueblePago.RowCount > 0)
            {
                InmueblePagoBE objInmueblePago = new InmueblePagoBE();
                objInmueblePago.IdInmueblePago = int.Parse(gvInmueblePago.GetFocusedRowCellValue("IdInmueblePago").ToString());
                objInmueblePago.TipoMovimiento = gvInmueblePago.GetFocusedRowCellValue("TipoMovimiento").ToString();

                frmRegInmueblePagoEdit objManInmueblePagoEdit = new frmRegInmueblePagoEdit();
                objManInmueblePagoEdit.pOperacion = frmRegInmueblePagoEdit.Operacion.Modificar;
                objManInmueblePagoEdit.IdInmueblePago = objInmueblePago.IdInmueblePago;
                objManInmueblePagoEdit.IdCliente = IdCliente;
                objManInmueblePagoEdit.TipoRegistro = objInmueblePago.TipoMovimiento;
                objManInmueblePagoEdit.IdInmueble = Convert.ToInt32(cboInmueble.EditValue);
                objManInmueblePagoEdit.StartPosition = FormStartPosition.CenterParent;
                objManInmueblePagoEdit.ShowDialog();

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

            if (gvInmueblePago.GetFocusedRowCellValue("IdInmueblePago").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    //txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                    CargarInmueble();
                    cboInmueble.Focus();
                    //txtDescCliente.Focus();
                }

                //if (frm.pClienteBE.IdTipoCliente == Parametros.intTipClienteFinal && frm.pClienteBE.IdClasificacionCliente != Parametros.intBlack)
                //{
                //    XtraMessageBox.Show("Atención! El cliente es MINORISTA se recomienda registrar en el estado de cuenta Soles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboInmueble_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }


    }
}
