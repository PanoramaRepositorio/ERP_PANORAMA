using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegCierreCaja : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CajaValorFijoBE> mLista = new List<CajaValorFijoBE>();
        private List<CajaCierreBE> mListaCierre = new List<CajaCierreBE>();

        int _IdCajaCierre = 0;

        public int IdCajaCierre
        {
            get { return _IdCajaCierre; }
            set { _IdCajaCierre = value; }
        }

         #endregion

        #region "Eventos"

        public frmRegCierreCaja()
        {
            InitializeComponent();
        }

        private void frmRegCierreCaja_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            TipoCambioBE objE_TipoCambio = null;
            objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Convert.ToDateTime(deFecha.EditValue));
            if (objE_TipoCambio == null)
            {
                XtraMessageBox.Show("El tipo de cambio del día no existe, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
                cboEmpresa.EditValue = Parametros.intEmpresaId;
                //BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescCaja", "IdCaja", true);
                cboTienda.EditValue = Parametros.intTiendaId;
                cboCaja.EditValue = Parametros.intCajaId;
                txtTipoCambio.EditValue = objE_TipoCambio.Compra;
                BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
                cboMoneda.EditValue = Parametros.intSoles;


                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rcastañeda")
                {
                    cboEmpresa.Enabled = true;
                    cboTienda.Enabled = true;
                }

                cboMoneda.Select();

                    XtraMessageBox.Show("RECORDATORIO: \n \n - Realizar el cierre de LOTE", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (Parametros.intPerfilId == Parametros.intPerCajeroCentral || Parametros.intPerfilId == Parametros.intPerCajeroSucursal
                    || Parametros.intPerfilId == Parametros.intPerCajeroSucursal || Parametros.intPerfilId == Parametros.intPerAdministradorTienda)
                {
                        XtraMessageBox.Show("RECORDATORIO: \n \n - Realizar el cierre de LOTE", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }

        private void gvDenominacion_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalGeneral = 0;
                decimal decCantidad = 0;

                if (e.Column.Caption == "Cantidad")
                {
                    //if (decimal.Parse(e.Value.ToString()) > 0)
                    //{
                        decCantidad = decimal.Parse(e.Value.ToString());
                        //Calcular Total
                        decTotal = decCantidad * Convert.ToDecimal(gvDenominacion.GetRowCellValue(e.RowHandle, (gvDenominacion.Columns["Denominacion"])));
                        gvDenominacion.SetRowCellValue(e.RowHandle, gvDenominacion.Columns["Total"], decTotal);
                        
                    //}
                }
            //--calculamos el total general ------------
                for (int i = 0; i < gvDenominacion.RowCount; i++)
                {
                    decTotalGeneral = decTotalGeneral  + Convert.ToDecimal(gvDenominacion.GetRowCellValue(i, (gvDenominacion.Columns["Total"])));
                }
                txtTotal.EditValue = decTotalGeneral;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            InsertarCajaValorFijo();
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();

            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }

        private void cboCaja_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Está seguro de Cerrar esta Caja?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CajaCierreBL objBL_CajaCierre = new CajaCierreBL();
                CajaCierreBE objE_CajaCierre = new CajaCierreBE();
                objE_CajaCierre.IdCajaCierre = IdCajaCierre;
                objE_CajaCierre.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                objE_CajaCierre.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objE_CajaCierre.TotalVisa = Convert.ToInt32(txtTotalVisa.EditValue);
                objE_CajaCierre.TotalMastercard = Convert.ToInt32(txtTotaMastercard.EditValue);
                objE_CajaCierre.FlagEstado = true;
                objE_CajaCierre.Usuario = Parametros.strUsuarioLogin;
                objE_CajaCierre.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                objBL_CajaCierre.Inserta(objE_CajaCierre);
                XtraMessageBox.Show("Caja Cerrada correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DesHabilitarBotones();
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CajaValorFijoBL().ListaTodosActivo(Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), "F", Convert.ToInt32(cboMoneda.EditValue));
            gcDenominacion.DataSource = mLista;

            CalculaTotales();

        }

        private void CalculaTotales()
        {
            try
            {
                decimal deTotal = 0;

                if (mLista.Count > 0)
                {
                    foreach (var item in mLista)
                    {
                        deTotal = deTotal + (item.Denominacion * item.Cantidad);
                    }

                    txtTotal.EditValue = Math.Round(deTotal, 2);
                }
                else
                {
                     txtTotal.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarCajaValorFijo()
        {
            //if (!ValidarIngreso())
            //{
                CajaValorFijoBL objBL_DocumentoVenta = new CajaValorFijoBL();

                List<CajaValorFijoBE> lstCajaValorFijo= null;
                lstCajaValorFijo= new List<CajaValorFijoBE>();

                foreach (var item in mLista)
                {
                    CajaValorFijoBE objE_CajaValorFijo= new CajaValorFijoBE();
                    objE_CajaValorFijo.IdCajaValorFijo = item.IdCajaValorFijo;
                    objE_CajaValorFijo.IdCaja = item.IdCaja;
                    objE_CajaValorFijo.Fecha = item.Fecha;
                    objE_CajaValorFijo.TipoValor = item.TipoValor;
                    objE_CajaValorFijo.IdMoneda = item.IdMoneda;
                    objE_CajaValorFijo.Denominacion = item.Denominacion;
                    objE_CajaValorFijo.Cantidad = item.Cantidad;
                    objE_CajaValorFijo.Total = item.Total;
                    objE_CajaValorFijo.FlagEstado = true;
                    lstCajaValorFijo.Add(objE_CajaValorFijo);
                }

                objBL_DocumentoVenta.Actualiza(lstCajaValorFijo);
                XtraMessageBox.Show("Datos guardados correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (mLista.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar el Cierre, mientra no haya registros.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
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
            btnGrabar.Enabled = true;
            btnCerrarCaja.Enabled = true;
            btnEliminarCierre.Enabled = false;
        }

        private void DesHabilitarBotones()
        {
            btnGrabar.Enabled = false;
            btnCerrarCaja.Enabled = false;
            btnEliminarCierre.Enabled = true;
        }


        #endregion

        private void btnEliminarCierre_Click(object sender, EventArgs e)
        {
            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            frmAutoriza.ShowDialog();

            if (frmAutoriza.Edita)
            {
                if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master")
                {
                    CajaCierreBL objBL_CajaCierre = new CajaCierreBL();
                    CajaCierreBE objE_CajaCierre = new CajaCierreBE();
                    objE_CajaCierre.IdCajaCierre = IdCajaCierre;
                    objE_CajaCierre.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objE_CajaCierre.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_CajaCierre.FlagEstado = false;
                    objE_CajaCierre.Usuario = Parametros.strUsuarioLogin;
                    objE_CajaCierre.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_CajaCierre.EliminaFecha(objE_CajaCierre);
                    XtraMessageBox.Show("Caja Abierta!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HabilitarBotones();
                }
                else
                {
                    XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            List<CajaCierreBE> Obj_CajaCierre = new List<CajaCierreBE>();
            Obj_CajaCierre = new CajaCierreBL().ListaFechaCaja(Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToInt32(cboCaja.EditValue));

            if (Obj_CajaCierre.Count > 0)
            {
                List<ReporteMovimientoCajaBE> lstReporte = null;
                lstReporte = new ReporteMovimientoCajaBL().ListadoDocumentoResumen(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));
                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        List<ReporteMovimientoCajaBE> lstReporteTarjeta = null;
                        lstReporteTarjeta = new ReporteMovimientoCajaBL().ListadoTarjeta(0, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue));

                        RptVistaReportes objRptMovimientoCaja = new RptVistaReportes();
                        objRptMovimientoCaja.VerRptMovimientoCajaTarjetaDocumentoResumen(lstReporte, lstReporteTarjeta);
                        objRptMovimientoCaja.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                XtraMessageBox.Show("La Caja no está Cerrada!, no se puede Imprimir, Consulte con su administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }



        }



    }
}