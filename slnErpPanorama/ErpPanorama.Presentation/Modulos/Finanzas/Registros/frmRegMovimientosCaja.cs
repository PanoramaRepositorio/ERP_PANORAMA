using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Funciones;
using System.Drawing.Printing;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid.Views.Grid;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegMovimientosCaja: DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        //public List<PrestamoBancoBE> lstPrestamoBanco;
        public List<CCajaEgresoDetalle> mCajaEgresoDetalleOrigen = new List<CCajaEgresoDetalle>();

        public List<CuentaBancoBE> mListaCuentaBanco = new List<CuentaBancoBE>();
        //public enum Operacion
        //{
        //    Nuevo = 1,
        //    Modificar = 2,
        //    Eliminar = 3,
        //    Consultar = 4
        //}

        public int IdSituacion = 0;
        public int IdEmpresa = 0;
        public string Empresa = "";
        public string NombreCaja = "";
        public int IdMoneda = 0;
        public decimal ImporteSaldoInicial = 0;

        private int IdPersona = 0;
        private int IdCliente=0;
        private string Usuario = "";
        public int IdSolicitudEgreso = 0;
        public int IdSolicitudEgresoDetalle = 0;
        public string NumeroGenerado = "";
        public int CantidadDet = 0;
        public int IdCuentaBanco = 0;

        int _IdCajaEgreso = 0;
        public int IdCajaEgreso
        {
            get { return _IdCajaEgreso; }
            set { _IdCajaEgreso = value; }
        }
 
        #endregion

        #region "Eventos"
        public frmRegMovimientosCaja()
        {
            InitializeComponent();
        }

        private void frmRegMovimientosCaja_Load(object sender, EventArgs e)
        {
            txtEmpresa.Text = Empresa;
            txtCaja.Text = NombreCaja;
            cboFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = IdMoneda; /// Parametros.intSoles;
            txtMoneda.Text = IdMoneda==5? "SOLES" : "DOLARES";

            BSUtils.LoaderLook(cboOperacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblOperacionCaja), "DescTablaElemento", "IdTablaElemento", true);
            cboOperacion.EditValue = Parametros.intOperacionEgreso;

            BSUtils.LoaderLook(cboTipoEgreso, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 89), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosTiendasActivo2(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);

            txtSaldoInicial.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(ImporteSaldoInicial, 2)));  
            CargaMovimientosCajaDetalle();
            CalculaTotales();

            if (IdSituacion==2)
            {
                simpleButton1.Enabled = false;
                simpleButton3.Enabled = false;
            }

            if (Parametros.intPerfilId == 1 || Parametros.intPerfilId == 65)
            {
                checkRevisadoToolStripMenuItem.Enabled = true;
            }
            else
            {
                checkRevisadoToolStripMenuItem.Enabled = false;
            }
        }

        private void CargaMovimientosCajaDetalle()
        {
            List<CajaEgresoDetalleBE> lstTmpCajaEgresoDetalle = null;
            lstTmpCajaEgresoDetalle = new CajaEgresoDetalleBL().ListaTodosActivo(IdCajaEgreso);

            foreach (CajaEgresoDetalleBE item in lstTmpCajaEgresoDetalle)
            {
                CCajaEgresoDetalle objE_SolicitudEgresoDetalle = new CCajaEgresoDetalle();

                objE_SolicitudEgresoDetalle.IdCajaEgreso = item.IdCajaEgreso;
                objE_SolicitudEgresoDetalle.IdCajaEgresoDetalle = item.IdCajaEgresoDetalle;
                objE_SolicitudEgresoDetalle.TipoOperacion = item.TipoOperacion;
                objE_SolicitudEgresoDetalle.Operacion = item.Operacion;
                objE_SolicitudEgresoDetalle.Fecha = item.Fecha;
                objE_SolicitudEgresoDetalle.NumRecibo = item.NumRecibo;
                objE_SolicitudEgresoDetalle.Recibio = item.Recibio;
                objE_SolicitudEgresoDetalle.Concepto = item.Concepto;
                objE_SolicitudEgresoDetalle.ImporteIngreso = item.ImporteIngreso;
                objE_SolicitudEgresoDetalle.ImporteEgreso = item.ImporteEgreso;
                objE_SolicitudEgresoDetalle.ImporteRendicion = item.ImporteRendicion;
                objE_SolicitudEgresoDetalle.ImporteDevuelto = item.ImporteDevuelto;
                objE_SolicitudEgresoDetalle.EAdicional = item.EAdicional;
                objE_SolicitudEgresoDetalle.Total = item.Total;
                objE_SolicitudEgresoDetalle.PorRendir = item.PorRendir;
                objE_SolicitudEgresoDetalle.UsuarioCreacion = item.UsuarioCreacion;
                objE_SolicitudEgresoDetalle.NumDocumento = item.NumDocumento;
                objE_SolicitudEgresoDetalle.FlagEstado = item.FlagEstado;
                objE_SolicitudEgresoDetalle.FlagEAdicional = item.FlagEAdicional;
                objE_SolicitudEgresoDetalle.FlagRevisa = item.FlagRevisa;

                objE_SolicitudEgresoDetalle.IdTienda = item.IdTienda;
                objE_SolicitudEgresoDetalle.IdTipoEgreso = item.IdTipoEgreso;

                //   objE_SolicitudEgresoDetalle.TipoOper = Convert.ToInt32(Operacion.Consultar);

                mCajaEgresoDetalleOrigen.Add(objE_SolicitudEgresoDetalle);
            }

            bsListado.DataSource = mCajaEgresoDetalleOrigen;
            gcMovimientoCaja.DataSource = bsListado;
            gcMovimientoCaja.RefreshDataSource();

           // lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
        }

        public class CCajaEgresoDetalle
        {
            public Int32 IdCajaEgreso { get; set; }
            public Int32 IdCajaEgresoDetalle { get; set; }
            public Int32 TipoOperacion { get; set; }
            public String Operacion { get; set; }
            public DateTime ?Fecha { get; set; }
            public String  NumRecibo { get; set; }
            public Int32 TipoPersona { get; set; }
            public Int32 IdPersona { get; set; }
            public String NumDocumento { get; set; }
            public String Recibio { get; set; }
            public String Concepto { get; set; }
            public Int32 IdMoneda { get; set; }
            public Decimal ImporteIngreso { get; set; }
            public Decimal ImporteEgreso { get; set; }
            public Decimal ImporteRendicion { get; set; }
            public Decimal ImporteDevuelto { get; set; }
            public Decimal EAdicional { get; set; }
            public Decimal PorRendir { get; set; }
            public Decimal Total { get; set; }
            public String UsuarioCreacion { get; set; }
            public Int32 FlagEstado { get; set; }
            public Boolean FlagEAdicional { get; set; }
            public Int32 TipoOper { get; set; }
            public Boolean FlagRevisa { get; set; }
            public Int32 IdTienda { get; set; }
            public Int32 IdTipoEgreso { get; set; }
            public CCajaEgresoDetalle()
            {

            }
        }

        private void CalculaTotales()
        {
            try
            {
                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;

                decimal TotalIngreso = 0;
                decimal TotalEgreso = 0;
                decimal TotalRendicion = 0;

                decimal deTotal22 = 0;
                int intTotalCantidad = 0;

                if (mCajaEgresoDetalleOrigen.Count > 0)
                {
                    foreach (var item in mCajaEgresoDetalleOrigen)
                    {
                        //  intTotalCantidad = intTotalCantidad + item.Cantidad;
                        if (item.FlagEstado==1)
                        {
                            if (item.TipoOperacion==1) // ingreso
                            {
                                if (item.NumRecibo != "APCE")
                                {
                                    TotalIngreso = TotalIngreso + item.ImporteIngreso;
                                }
                            }
                            else if (item.TipoOperacion == 2) //Egreso
                            {
                                if (item.FlagEstado == 1)
                                {
                                    TotalEgreso = TotalEgreso + item.ImporteEgreso;
                                }
                            }

                          //  TotalIngreso = TotalIngreso + item.ImporteDevuelto;


                            TotalRendicion = TotalRendicion + item.PorRendir;
                        }
                    }

                    txtTotalIngreso.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(TotalIngreso, 2)));
                    txtTotalEgreso.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(TotalEgreso, 2)));
                    txtSaldoFinal.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(ImporteSaldoInicial  - TotalEgreso + TotalIngreso, 2)));
                    txtTotalRendicion.Text = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(TotalRendicion, 2)));


                    //deTotal = Math.Round(deTotal, 2);
                    //deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    //deImpuesto = Math.Round(deTotal - deSubTotal, 2);
                    //txtTotal.EditValue = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(deTotal, 2)));
                    //txtSubTotal.EditValue = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(deSubTotal, 2)));
                    //txtIgv.EditValue = Convert.ToString(String.Format("{0:#,##0.00}", Math.Round(deImpuesto, 2)));

                    //if (Convert.ToDecimal(txtDescuento.EditValue) > 0 || Convert.ToDecimal(txtDescuento.EditValue) > 0)
                    //{
                    //    deTotal22 = deTotal;
                    //    txtTotalBruto.EditValue = Math.Round(deTotal, 2);
                    //    deTotal = deTotal * ((100 - Math.Round((Convert.ToDecimal(txtTotalDescuento.EditValue) * 100) / Convert.ToDecimal(txtTotalBruto.EditValue), 15)) / 100);


                    //    txtDescuento.EditValue = Math.Round((Convert.ToDecimal(txtTotalDescuento.EditValue) * 100) / Convert.ToDecimal(txtTotalBruto.EditValue), 15);

                    //    txtTotal.Text = Math.Round(deTotal, 2).ToString();
                    //    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    //    txtSubTotal.EditValue = deSubTotal;
                    //    deImpuesto = deTotal - deSubTotal;
                    //}
                }
                else
                {
                    txtTotalIngreso.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtTotalEgreso.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtSaldoFinal.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    txtTotalEgreso.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegPrestamoBancoEdit_Shown(object sender, EventArgs e)
        {
            //NumCar = 1;
        }

        private void cboCuentaBanco_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string _file_excel = "";
            OpenFileDialog objOpenFileDialog = new OpenFileDialog();
            objOpenFileDialog.Filter = "All Archives of Microsoft Office Excel|*.xlsx;*.xls;*.csv";
            if (objOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                _file_excel = objOpenFileDialog.FileName;
                ImportarExcel(_file_excel);
                //Cargar();
            }
        }

        private void cancelarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion == Parametros.intSITPagoCancelado)
                {
                    XtraMessageBox.Show("La cuota ya está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    frmEstablecerFecha frm = new frmEstablecerFecha();
                    frm.Text = "Establecer Fecha de Pago";
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                        PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

                        int IdPrestamoBancoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                        //objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                        objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                        objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoCancelado;
                        objE_PrestamoBancoDetalle.FechaPago = frm.Fecha;
                        objE_PrestamoBancoDetalle.Usuario = frmAutoriza.Usuario;//Parametros.strUsuarioLogin;
                        objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "DescSituacion", "CANCELADO");
                        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoCancelado);
                        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "FechaPago", frm.Fecha);
                        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "UsuarioPago", frmAutoriza.Usuario);//Parametros.strUsuarioLogin);

                        CalcularTotalSaldoPrestamo();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void gvPrestamoBancoDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal decTotal = 0;
                decimal decTotalGeneral = 0;
                decimal decAmortizacion = 0;
                decimal decInteres = 0;
                decimal decEnvioInfo = 0;
                decimal decDesgravamen = 0;
                decimal decSeguro = 0;

                if (e.Column.FieldName == "Monto")
                {
                    decAmortizacion = decimal.Parse(e.Value.ToString());
                    decAmortizacion = Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(e.RowHandle, (gvMovimientoCaja.Columns["Monto"])));
                    decInteres = Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(e.RowHandle, (gvMovimientoCaja.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(e.RowHandle, (gvMovimientoCaja.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(e.RowHandle, (gvMovimientoCaja.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(e.RowHandle, (gvMovimientoCaja.Columns["Seguro"])));


                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvMovimientoCaja.SetRowCellValue(e.RowHandle, gvMovimientoCaja.Columns["TotalPagar"], decTotal);
                }
                //if (e.Column.FieldName == "Interes")
                //{
                //    decInteres = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
                //if (e.Column.FieldName == "EnvioInformacion")
                //{
                //    decEnvioInfo = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
                //if (e.Column.FieldName == "Desgravamen")
                //{
                //    decDesgravamen = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
                //if (e.Column.FieldName == "Seguro")
                //{
                //    decSeguro = decimal.Parse(e.Value.ToString());
                //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
                //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

                //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCuotas_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (pOperacion == Operacion.Nuevo)
            //    {
            //        int nCuotas = 0;
            //        nCuotas = Convert.ToInt32(speFin.Value);  // txtCuotas.EditValue
            //        if (nCuotas > 0)
            //        {
            //            for (int i = 1; i <= nCuotas; i++)
            //            {
            //                gvMovimientoCaja.AddNewRow();
            //                gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "NumeroCuota", i);
            //            }
            //        }
            //    }
            //}
        }

        private void habilitarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdSituacion").ToString());
                if (IdSituacion != Parametros.intSITPagoCancelado)
                {
                    XtraMessageBox.Show("La cuota no está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita)
                {
                    PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
                    PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

                    int IdPrestamoBancoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                    //objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                    objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                    objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoPendiente;
                    objE_PrestamoBancoDetalle.FechaPago = null;
                    objE_PrestamoBancoDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "DescSituacion", "PENDIENTE");
                    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoPendiente);
                    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "FechaPago", null);
                    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "UsuarioPago", Parametros.strUsuarioLogin);

                    CalcularTotalSaldoPrestamo();

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text);
                //throw;
            }

        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";

            if (Convert.ToInt32(cboOperacion.EditValue) == Parametros.intOperacionIngreso)
            {
                if (txtReferenciaEgreso.Text.Trim().ToString() == "000000" || txtReferenciaEgreso.Text.Trim().ToString() == "")
                {
                    strMensaje = strMensaje + "- Ingrese el recibo de egreso de referencia.\n";
                    flag = true;
                }
            }

            if (txtApeNom.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el nombre de la persona que recibe.\n";
                flag = true;
            }

            if (txtConcepto.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el concepto del movimiento.\n";
                flag = true;
            }

            if (Convert.ToDecimal(txtImporte.Text) == 0)
            {
                strMensaje = strMensaje + "- Ingrese el importe del movimiento.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        //private void CargaPrestamoBancoDetalle()
        //{
        //    List<SolicitudEgresoDetalleBE> lstTmpPrestamoBancoDetalle = null;
        //    lstTmpPrestamoBancoDetalle = new SolicitudEgresoDetalleBL().ListaTodosActivo(IdSolicitudEgreso);

        //    foreach (SolicitudEgresoDetalleBE item in lstTmpPrestamoBancoDetalle)
        //    {
        //        CSolicitudEgresoDetalle objE_SolicitudEgresoDetalle = new CSolicitudEgresoDetalle();

        //        objE_SolicitudEgresoDetalle.IdSolicitudEgreso = item.IdSolicitudEgreso;
        //        objE_SolicitudEgresoDetalle.IdSolicitudEgresoDetalle = item.IdSolicitudEgresoDetalle;
        //        objE_SolicitudEgresoDetalle.NumAbono = item.NumeroAbono;
        //        objE_SolicitudEgresoDetalle.FechaPagoSolicitada2 =Convert.ToDateTime( item.FechaPagoSolicitada);
        //        objE_SolicitudEgresoDetalle.Monto = item.MontoAbono;

        //        //objE_SolicitudEgresoDetalle.TipoOper = Convert.ToInt32(Operacion.Consultar);

        //        mListaPrestamoBancoDetalleOrigen.Add(objE_SolicitudEgresoDetalle);
        //    }

        //    bsListado.DataSource = mListaPrestamoBancoDetalleOrigen;
        //    gcMovimientoCaja.DataSource = bsListado;
        //    gcMovimientoCaja.RefreshDataSource();

        //    lblTotalRegistros.Text = gvMovimientoCaja.RowCount.ToString() + " Registros";
        //}

        private void CargarCombo()
        {
            mListaCuentaBanco = new CuentaBancoBL().Lista(0);
            if (mListaCuentaBanco.Count > 0)
            {
                //cboCuentaBanco.Properties.DataSource = mListaCuentaBanco;

                //cboCuentaBanco.EditValue = mListaCuentaBanco[0].IdCuentaBanco;
                //cboCuentaBanco.Properties.DisplayMember = "DescBanco";

            }
        }

        private void ImportarExcel(string filename)
        {
            //if (pOperacion == Operacion.Nuevo)
            //{
            //    XtraMessageBox.Show("Debe grabar al menos un código, luego abrir e importar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
            int TotalAgregado = 0;
            int TotalActualizado = 0;
            decimal decAmortizacion = 0;
            decimal decTotalInteres = 0;
            decimal decInteres = 0;
            int intCuotas = 0;
            DateTime FechaVen= DateTime.Now;
            string sNumeroPrestamo = "";


            if (filename.Trim() == "")
                return;

            Excel._Application xlApp;
            Excel._Workbook xlLibro;
            Excel._Worksheet xlHoja;
            Excel.Sheets xlHojas;
            xlApp = new Excel.Application();
            xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            xlHojas = xlLibro.Sheets;
            xlHoja = (Excel._Worksheet)xlHojas[1];

            int Row = 2;
            int TotRow = 2;

            try
            {
                //Contador de Registros
                while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                        TotRow++;
                }
                TotRow = TotRow - Row + 1;
                //prgFactura.Properties.Step = 1;
                //prgFactura.Properties.Maximum = TotRow;
                //prgFactura.Properties.Minimum = 0;


                //Recorremos los códigos de PromocionTemporal
                while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
                {
                    string NumeroCuota = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
                    DateTime FechaVencimiento = Convert.ToDateTime((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
                    string SaldoPendiente = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
                    string Amortizacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();
                    string Interes = (string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim();
                    string EnvioInformacion = (string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim();
                    string Desgravamen = (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim();
                    string Seguro = (string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim();
                    string TotalPagar = (string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim();
                    string Moneda = (string)xlHoja.get_Range("J" + Row, Missing.Value).Text.ToString().Trim();
                    string Cuotas = (string)xlHoja.get_Range("K" + Row, Missing.Value).Text.ToString().Trim();
                    string NumeroPrestamo = (string)xlHoja.get_Range("L" + Row, Missing.Value).Text.ToString().Trim();


                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    //    gvMovimientoCaja.AddNewRow();
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "IdPrestamoBanco", IdPrestamoBanco);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "IdPrestamoBancoDetalle", 0);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "NumeroCuota", NumeroCuota);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "FechaVencimiento", FechaVencimiento);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "SaldoPendiente", SaldoPendiente);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Amortizacion", Amortizacion);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Interes", Interes);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Desgravamen", Desgravamen);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "Seguro", Seguro);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "TotalPagar", TotalPagar);
                    //    gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "FlagEstado", true);
                    //    if (pOperacion == Operacion.Modificar)
                    //        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                    //    else
                    //        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                    //    TotalAgregado = TotalAgregado + 1;
                    //}

                    decTotalInteres = decTotalInteres + Convert.ToDecimal(Interes);
                    decInteres = decInteres + Convert.ToDecimal(Interes);
                    intCuotas = Convert.ToInt32(Cuotas);
                    FechaVen = FechaVencimiento;
                    sNumeroPrestamo = NumeroPrestamo;
                    decAmortizacion = decAmortizacion + Convert.ToDecimal(Amortizacion);
                    //prgFactura.PerformStep();
                    //prgFactura.Update();

                    Row++;
                }
              //  lblTotalRegistros.Text = gvMovimientoCaja.RowCount.ToString() + " Registros";



                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                //if (pOperacion == Operacion.Modificar)
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotalSaldoPrestamo()
        {
            try
            {
                decimal decSaldo = 0;
                decimal decInteres = 0;
                decimal decTotalInteres = 0;
                decimal decMayorSaldo = 0;
                int intSituacion = 0;

                for (int i = 0; i < gvMovimientoCaja.RowCount; i++)
                {
                    intSituacion = Convert.ToInt32(gvMovimientoCaja.GetRowCellValue(i, (gvMovimientoCaja.Columns["IdSituacion"])));

                    decSaldo = Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(i, (gvMovimientoCaja.Columns["SaldoPendiente"])));
                    decInteres = Convert.ToDecimal(gvMovimientoCaja.GetRowCellValue(i, (gvMovimientoCaja.Columns["Interes"])));

                    if (intSituacion != Parametros.intSITPagoCancelado)
                    {
                        decTotalInteres = decTotalInteres + decInteres;

                        if(decSaldo > decMayorSaldo)
                        {
                            decMayorSaldo = decSaldo;
                        }
                    }
                }
                //txtSaldoPrestamo.EditValue = decMayorSaldo;
                //txtSaldoInteres.EditValue = decTotalInteres;
                //lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarIngreso())
                {
                    CajaEgresoDetalleBL objBL_CajaEgreso = new CajaEgresoDetalleBL();
                    CajaEgresoDetalleBE objCajaEgresoDetalle = new CajaEgresoDetalleBE();

                    objCajaEgresoDetalle.IdEmpresa = IdEmpresa;
                    objCajaEgresoDetalle.IdCajaEgreso = IdCajaEgreso;
                    if (Convert.ToInt32(cboOperacion.EditValue) == Parametros.intOperacionIngreso)
                    {
                        objCajaEgresoDetalle.TipoOperacion = 1;  // Ingreso
                        objCajaEgresoDetalle.Concepto = txtConcepto.Text.Trim() + " - " + "(Ref. Recibo de Egreso " + txtReferenciaEgreso.Text.Trim() + ")";
                        objCajaEgresoDetalle.IdTienda = 0;
                        objCajaEgresoDetalle.IdTipoEgreso = 0;
                    }
                    else
                    {
                        if (Convert.ToInt32(cboTienda.EditValue) == 0)
                        {
                            XtraMessageBox.Show("Seleccione la tienda para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboTienda.Select();
                            return;
                        }

                        if (Convert.ToInt32(cboTipoEgreso.EditValue) == 0)
                        {
                            XtraMessageBox.Show("Seleccione el tipo de egreso para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cboTipoEgreso.Select();
                            return;
                        }

                        if (Convert.ToDecimal(txtImporte.Text) > Convert.ToDecimal(txtSaldoFinal.Text))
                        {
                            XtraMessageBox.Show("El importe ingresado supera el Saldo actual.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        objCajaEgresoDetalle.TipoOperacion = 2;  // Egreso
                        objCajaEgresoDetalle.Concepto = txtConcepto.Text.Trim();
                    }
                    objCajaEgresoDetalle.Fecha = Convert.ToDateTime(cboFecha.EditValue);
                    objCajaEgresoDetalle.NumRecibo = txtReciboCaja.Text.Trim();
                    objCajaEgresoDetalle.TipoPersona = rb1.Checked ? 1 : 2;
                    objCajaEgresoDetalle.IdPersona = IdPersona;
                    objCajaEgresoDetalle.NumDocumento = txtNumeroDocumento.Text.Trim();
                    objCajaEgresoDetalle.Recibio = txtApeNom.Text.Trim();

                    objCajaEgresoDetalle.Importe = Convert.ToDecimal(txtImporte.Text.Trim());
                    objCajaEgresoDetalle.Referencia = txtReferenciaEgreso.Text.Trim();
                    objCajaEgresoDetalle.FlagEAdicional = Convert.ToBoolean(chkEgresoAdiconal.Checked);

                    objCajaEgresoDetalle.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objCajaEgresoDetalle.IdTipoEgreso = Convert.ToInt32(cboTipoEgreso.EditValue);

                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    int ValorIdCajaEgresoDet =   objBL_CajaEgreso.Inserta(objCajaEgresoDetalle);

                    //****
                    List<CajaEgresoDetalleBE> lstReporte = null;
                    lstReporte = new CajaEgresoDetalleBL().ListadoPrint(ValorIdCajaEgresoDet);

                    CreaTicketCajaEgreso ticket = new CreaTicketCajaEgreso();

                    // IMPRESIÓN DE TICKET
                    #region "Impresión Recibo"
                    for (int i = 1; i <= 2; i++)
                    {
                        ticket.TextoCentro("---------------------------------------------");
                        if (lstReporte[0].TipoOperacion == 1)
                        {
                            ticket.TextoCentro("RECIBO DE INGRESO " + ": Nro. " + lstReporte[0].NumRecibo.ToString());
                        }
                        else
                        {
                            ticket.TextoCentro("RECIBO DE EGRESO " + ": Nro. " + lstReporte[0].NumRecibo.ToString());
                            ticket.TextoCentro(lstReporte[0].NombreCaja.ToString());
                        }
                        ticket.TextoCentro("---------------------------------------------");
                        ticket.TextoCentro("");
                        ticket.TextoIzquierda("FECHA   " + ": " + lstReporte[0].Fecha.ToString());
                        if (lstReporte[0].IdEmpresa == 13)
                        {
                            ticket.TextoIzquierda("RUC     " + ": " + lstReporte[0].Ruc);
                            ticket.TextoIzquierda("EMPRESA " + ": " + "PANORAMA DISTRIBUIDORES S.A.");
                        }
                        else if (lstReporte[0].IdEmpresa == 27)
                        {
                            ticket.TextoIzquierda("RUC     " + ": " + lstReporte[0].Ruc);
                            ticket.TextoIzquierda("EMPRESA " + ": " + "DECORATEX E.I.R.L.");
                        }
                        ticket.TextoIzquierda("CAJA    " + ": " + lstReporte[0].De);
                        ticket.TextoCentro("");

                        if (lstReporte[0].TipoOperacion == 1)
                        {
                            ticket.TextoIzquierda("DEVUELVE: ");
                            ticket.TextoIzquierda("NOMBRES " + ": " + lstReporte[0].Recibio);
                            ticket.TextoIzquierda("REFERENCIA RECIBO DE EGRESO " + ": Nro. " + lstReporte[0].Referencia.ToString());
                            ticket.TextoCentro("");
                        }
                        ticket.TextoIzquierda("DATOS DEL QUE RECIBE:");

                        if (lstReporte[0].TipoOperacion == 1)
                        {
                            ticket.TextoIzquierda("DNI/CE " + ": ");
                            ticket.TextoIzquierda("CAJA " + ": " + lstReporte[0].De);
                        }
                        else if (lstReporte[0].TipoOperacion == 2)
                        {
                            ticket.TextoIzquierda("DNI/CE " + ": " + lstReporte[0].NumDocumento);
                            ticket.TextoIzquierda("RECIBI " + ": " + lstReporte[0].Recibio);
                        }
                        ticket.TextoIzquierdaNLineas("CONCEPTO " + ": " + lstReporte[0].Concepto);
                        ticket.TextoCentro("");
                        ticket.TextoIzquierda("IMPORTE    " + ": S/ " + lstReporte[0].Importe);
                        ticket.TextoIzquierdaNLineas("LA SUMA DE " + ": " + lstReporte[0].ImporteTexto);
                        ticket.TextoCentro("");
                        ticket.TextoCentro("");
                        ticket.TextoCentro("");
                        ticket.TextoCentro("");
                        ticket.TextoCentro("__________________________________");
                        ticket.TextoCentro("RECIBI");
                        ticket.TextoCentro("");
                        ticket.TextoCentro("");
                        ticket.TextoCentro("");
                        ticket.TextoCentro("");
                        ticket.TextoCentro("__________________________________");
                        ticket.TextoCentro("ENTREGE");
                        ticket.CortaTicket();
                    }
                    #endregion
                    //***

                    bsListado.Clear();
                    gcMovimientoCaja.DataSource = null;
                    gcMovimientoCaja.RefreshDataSource();

                    CargaMovimientosCajaDetalle();
                    CalculaTotales();

                    rb1.Checked = true;
                    rb2.Checked = false;
                    IdPersona = 0;
                    txtApeNom.Text = "";
                    txtConcepto.Text = "";
                    txtImporte.Text = Convert.ToString(String.Format("{0:#,##0.00}", 0));
                    cboOperacion.EditValue = Parametros.intOperacionEgreso;
                    txtNumeroDocumento.Text = "";
                    cboTienda.EditValue = 15;
                    cboTipoEgreso.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAsignar_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCentroCosto_EditValueChanged(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (rb1.Checked)
                    {
                        if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                        {
                            PersonaBE objE_Persona = null;
                            objE_Persona = new PersonaBL().SeleccionaPersonal(txtNumeroDocumento.Text.Trim());
                            if (objE_Persona != null)
                            {
                                IdPersona = objE_Persona.IdPersona;
                                txtNumeroDocumento.Text = objE_Persona.Dni.Trim();
                                txtApeNom.Text = objE_Persona.ApeNom.Trim();
                            }
                            else
                            {
                                XtraMessageBox.Show("El personal no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            btnBuscar_Click(sender, e);
                        }
                    }
                    else if (rb2.Checked)
                    {
                        txtApeNom.Select();


                    }

                }
            }
            catch (Exception ex)
            {
               // XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                frmBusPersonal frm = new frmBusPersonal();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pProveedorBE != null)
                {

                    IdPersona = frm.pProveedorBE.IdPersona;
                    txtNumeroDocumento.Text = frm.pProveedorBE.Dni;
                    txtApeNom.Text = frm.pProveedorBE.ApeNom;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCuentaBancoProveedor_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboOperacion.EditValue)==Parametros.intOperacionIngreso)
            {
                lblReferencia.Visible = true;
                txtReferenciaEgreso.Visible = true;
                txtReferenciaEgreso.Text = "";
                lblRecibio.Text = "Devuelve:";
                cboTienda.Visible = false;
                cboTipoEgreso.Visible = false;
                lblTienda.Visible = false;
                lblTipoEgreso.Visible = false;
                txtReferenciaEgreso.Select();
            }
            else  
            {
                lblReferencia.Visible = false;
                txtReferenciaEgreso.Visible = false;
                lblRecibio.Text = "Recibe:";
                cboTienda.Visible = true;
                cboTipoEgreso.Visible = true;
                lblTienda.Visible = true;
                lblTipoEgreso.Visible = true;
                cboTipoEgreso.Select();
            }
            //CuentaBancoBE objBE_CuentaBancoProveedor = null;
            //objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
            //if (objBE_CuentaBancoProveedor != null)
            //{
            //    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
            //    txtCCI.EditValue = objBE_CuentaBancoProveedor.CCI;
            //}
            //else
            //{
            //    txtCuenta.EditValue = "";
            //    txtCCI.EditValue = "";
            //}
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    txtCuenta.EditValue = "";
            //    cboCuentaBancoProveedor.EditValue=0;
            //    BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

            //    CuentaBancoBE objBE_CuentaBancoProveedor = null;
            //    objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
            //    if (objBE_CuentaBancoProveedor != null)
            //    {
            //        txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
            //        txtCCI.EditValue = objBE_CuentaBancoProveedor.CCI;
            //    }
            //    else
            //{
            //        txtCuenta.EditValue = "";
            //        txtCCI.EditValue = "";
            //    }
            //}
            //catch (Exception ex)
            //{
            //   // XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusClienteSolicitud frm = new frmBusClienteSolicitud();
                frm.pNumeroDescCliente = "";
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    //txtAFacturar.Text = frm.pClienteBE.DescCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rb1_Click(object sender, EventArgs e)
        {
            if (rb1.Checked)
            {
                IdPersona = 0;
                txtNumeroDocumento.Text = "";
                txtApeNom.Text = "";
                txtApeNom.ReadOnly = true;
            }
            btnBuscar.Enabled = true;
            txtNumeroDocumento.Select();
        }

        private void rb2_Click(object sender, EventArgs e)
        {
            if (rb2.Checked)
            {
                IdPersona =0;
                txtNumeroDocumento.Text = "";
                txtApeNom.Text = "";
                txtApeNom.ReadOnly = false;
            }
            btnBuscar.Enabled = false;
            txtNumeroDocumento.Select();
        }

        private void rb1_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refrescarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bsListado.Clear();
            gcMovimientoCaja.DataSource = null;
            gcMovimientoCaja.RefreshDataSource();

            CargaMovimientosCajaDetalle();
            CalculaTotales();
        }

        private void txtReferenciaEgreso_KeyUp(object sender, KeyEventArgs e)
        {
                
            if (e.KeyCode == Keys.Enter)
            {
                this.txtReferenciaEgreso.Text = txtReferenciaEgreso.Text.ToString().PadLeft(6, '0');
                if (this.txtReferenciaEgreso.Text == "000000" || this.txtReferenciaEgreso.Text == "")
                {
                    XtraMessageBox.Show("Ingrese el Nro. de Recibo de referencia.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                List<CajaEgresoDetalleBE> lstReciboEgreso = null;
                lstReciboEgreso = new CajaEgresoDetalleBL().BuscanumEgreso(this.txtReferenciaEgreso.Text, IdCajaEgreso);
                if (lstReciboEgreso != null)
                {
                    //objCajaEgresoDetalle.TipoPersona = rb1.Checked ? 1 : 2;
                    if (lstReciboEgreso[0].TipoPersona==1)
                    {
                        IdPersona = lstReciboEgreso[0].IdPersona;
                        txtNumeroDocumento.Text = lstReciboEgreso[0].NumDocumento;
                        txtApeNom.Text = lstReciboEgreso[0].Recibio;
                        rb1.Checked = true;
                        rb2.Checked = false;
                    }
                    else
                    {
                        IdPersona = 0;
                        txtNumeroDocumento.Text = lstReciboEgreso[0].NumDocumento;
                        txtApeNom.Text = lstReciboEgreso[0].Recibio;
                        rb1.Checked = false;
                        rb2.Checked = true;
                    }
                }
                else
                {
                    XtraMessageBox.Show("El numero de Egreso no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }
        }

        private void eliminarReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdSituacion==2)
            {
                XtraMessageBox.Show("La caja esta cerrada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(gvMovimientoCaja.GetFocusedRowCellValue("NumRecibo").ToString()== "APCE")
            {
                XtraMessageBox.Show("El ingreso [APCE] por Saldo Inicial no puede ser Eliminado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("TipoOperacion").ToString())==1)
            {
                if (XtraMessageBox.Show("¿Está seguro de Eliminar el Recibo de Ingreso Nro. " + gvMovimientoCaja.GetFocusedRowCellValue("NumRecibo").ToString() +" ? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CajaEgresoDetalleBL objBL_CajaEgresoDetalle = new CajaEgresoDetalleBL();
                    CajaEgresoDetalleBE objCajaEgresoDetalle = new CajaEgresoDetalleBE();

                    objCajaEgresoDetalle.IdCajaEgresoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
                    objCajaEgresoDetalle.FlagEstado = 0;

                    objBL_CajaEgresoDetalle.Actualiza(objCajaEgresoDetalle);
                }
                else
                { return; }
            }
            else
            {
                if (XtraMessageBox.Show("¿Está seguro de Eliminar el Recibo de Egreso Nro. " + gvMovimientoCaja.GetFocusedRowCellValue("NumRecibo").ToString() + " ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CajaEgresoDetalleBL objBL_CajaEgresoDetalle = new CajaEgresoDetalleBL();
                    CajaEgresoDetalleBE objCajaEgresoDetalle = new CajaEgresoDetalleBE();

                    objCajaEgresoDetalle.IdCajaEgresoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
                    objCajaEgresoDetalle.FlagEstado = 0;

                    objBL_CajaEgresoDetalle.Actualiza(objCajaEgresoDetalle);
                }
                else
                { return; }
            }

            XtraMessageBox.Show("Se elimino satisfactoriamente el recibo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            bsListado.Clear();
            gcMovimientoCaja.DataSource = null;
            gcMovimientoCaja.RefreshDataSource();

            CargaMovimientosCajaDetalle();
            CalculaTotales();
        }

        private void txtReferenciaEgreso_TextChanged(object sender, EventArgs e)
        {
         //    txtReferenciaEgreso.Text = txtReferenciaEgreso.Text.ToString().PadLeft(6, '0');
        }

        private void txtReferenciaEgreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    txtNumeroDocumento.Focus();
            //}
        }

        private void txtApeNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtConcepto.Focus();
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter)
            //{
            //    txtApeNom.Focus();
            //}
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtImporte.Focus();
            }
        }

        private void reimprimirReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CajaEgresoDetalleBE> lstReporte = null;
            lstReporte = new CajaEgresoDetalleBL().ListadoPrint(int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString()));

            CreaTicketCajaEgreso ticket = new CreaTicketCajaEgreso();

            // IMPRESIÓN DE TICKET
            #region "Impresión Recibo"
            for (int i = 1; i <= 2; i++)
            {
                ticket.TextoCentro("---------------------------------------------");
                if (lstReporte[0].TipoOperacion == 1)
                {
                    ticket.TextoCentro("RECIBO DE INGRESO " + ": Nro. " + lstReporte[0].NumRecibo.ToString());
                }
                else
                {
                    ticket.TextoCentro("RECIBO DE EGRESO " + ": Nro. " + lstReporte[0].NumRecibo.ToString());
                    ticket.TextoCentro(lstReporte[0].NombreCaja.ToString());
                }
                ticket.TextoCentro("---------------------------------------------");
                ticket.TextoCentro("");
                ticket.TextoIzquierda("FECHA   " + ": " + lstReporte[0].Fecha.ToString());
                if (lstReporte[0].IdEmpresa == 13)
                {
                    ticket.TextoIzquierda("RUC     " + ": " + lstReporte[0].Ruc);
                    ticket.TextoIzquierda("EMPRESA " + ": " + "PANORAMA DISTRIBUIDORES S.A.");
                }
                else if (lstReporte[0].IdEmpresa == 27)
                {
                    ticket.TextoIzquierda("RUC     " + ": " + lstReporte[0].Ruc);
                    ticket.TextoIzquierda("EMPRESA " + ": " + "DECORATEX E.I.R.L.");
                }
                ticket.TextoIzquierda("CAJA    " + ": " + lstReporte[0].De);
                ticket.TextoCentro("");

                if (lstReporte[0].TipoOperacion == 1)
                {
                    ticket.TextoIzquierda("DEVUELVE: ");
                    ticket.TextoIzquierda("NOMBRES " + ": " + lstReporte[0].Recibio);
                    ticket.TextoIzquierda("REFERENCIA RECIBO DE EGRESO " + ": Nro. " + lstReporte[0].Referencia.ToString());
                    ticket.TextoCentro("");
                }
                ticket.TextoIzquierda("DATOS DEL QUE RECIBE:");

                if (lstReporte[0].TipoOperacion == 1)
                {
                    ticket.TextoIzquierda("DNI/CE " + ": ");
                    ticket.TextoIzquierda("CAJA " + ": " + lstReporte[0].De);
                }
                else if (lstReporte[0].TipoOperacion == 2)
                {
                    ticket.TextoIzquierda("DNI/CE " + ": " + lstReporte[0].NumDocumento);
                    ticket.TextoIzquierda("RECIBI " + ": " + lstReporte[0].Recibio);
                }

                ticket.TextoIzquierdaNLineas("CONCEPTO " + ": " + lstReporte[0].Concepto);
                ticket.TextoCentro("");
                ticket.TextoIzquierda("IMPORTE    " + ": S/ " + lstReporte[0].Importe);
                ticket.TextoIzquierdaNLineas("LA SUMA DE " + ": " + lstReporte[0].ImporteTexto);
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("__________________________________");
                ticket.TextoCentro("RECIBI");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("");
                ticket.TextoCentro("__________________________________");
                ticket.TextoCentro("ENTREGE");
                ticket.CortaTicket();
            }
                #endregion
        }

        private void registrarDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdSituacion == 2)
            {
                XtraMessageBox.Show("La caja esta cerrada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmRegistroDocumentos objRegistroDocumentos = new frmRegistroDocumentos();
            objRegistroDocumentos.IdEmpresa = IdEmpresa;
            objRegistroDocumentos.IdCajaEgreso = IdCajaEgreso;
            objRegistroDocumentos.IdCajaEgresoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
            objRegistroDocumentos.IdMoneda = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdMoneda").ToString());
            objRegistroDocumentos.Empresa = txtEmpresa.Text;
            objRegistroDocumentos.NumRecibo = gvMovimientoCaja.GetFocusedRowCellValue("NumRecibo").ToString();
            objRegistroDocumentos.NumDocumento = gvMovimientoCaja.GetFocusedRowCellValue("NumDocumento").ToString();
            objRegistroDocumentos.Nombres = gvMovimientoCaja.GetFocusedRowCellValue("Recibio").ToString();
            objRegistroDocumentos.ConceptoRef = gvMovimientoCaja.GetFocusedRowCellValue("Concepto").ToString();

            objRegistroDocumentos.vIdTienda = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTienda").ToString());
            objRegistroDocumentos.vIdTipoEgreso = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdTipoEgreso").ToString());

            if (int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("TipoOperacion").ToString())==1 )  //Ingreso
            {
                objRegistroDocumentos.MontoRecibo = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteIngreso").ToString());
                XtraMessageBox.Show("No puede registrar documentos en un ingreso (vuelto).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                objRegistroDocumentos.MontoRecibo = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteEgreso").ToString());
                objRegistroDocumentos.MontoDevolucion = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteDevuelto").ToString());

                CajaEgresoDetalleBL objBL_CajaEgreso = new CajaEgresoDetalleBL();
                CajaEgresoDetalleBE objCajaEgresoDetalle = new CajaEgresoDetalleBE();

                objCajaEgresoDetalle.IdCajaEgreso = IdCajaEgreso;
                objCajaEgresoDetalle.IdCajaEgresoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
                objCajaEgresoDetalle.IdEmpresa = IdEmpresa;
                objCajaEgresoDetalle.NumRecibo = gvMovimientoCaja.GetFocusedRowCellValue("NumRecibo").ToString();
                objCajaEgresoDetalle.Importe = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteEgreso").ToString());
                objCajaEgresoDetalle.Fecha = Convert.ToDateTime(gvMovimientoCaja.GetFocusedRowCellValue("Fecha").ToString());

                objBL_CajaEgreso.Inserta_DocsEgresos(objCajaEgresoDetalle);

            }

            objRegistroDocumentos.StartPosition = FormStartPosition.CenterParent;
            objRegistroDocumentos.ShowDialog();

            ///
            //if (int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("TipoOperacion").ToString()) == 2)  //Egreso
            //{
            //    CajaEgresoDetalleBL objBL_CajaEgreso = new CajaEgresoDetalleBL();
            //    CajaEgresoDetalleBE objCajaEgresoDetalle = new CajaEgresoDetalleBE();

            //    objCajaEgresoDetalle.IdCajaEgreso = IdCajaEgreso;
            //    objCajaEgresoDetalle.IdCajaEgresoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
            //    objCajaEgresoDetalle.IdEmpresa = IdEmpresa;
            //    objCajaEgresoDetalle.ImporteEgreso = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteEgreso").ToString());
            //    objCajaEgresoDetalle.Fecha = Convert.ToDateTime(gvMovimientoCaja.GetFocusedRowCellValue("Fecha").ToString());

            //    objBL_CajaEgreso.Inserta_DocsEgresos(objCajaEgresoDetalle);
            //}
            ///

            bsListado.Clear();
            gcMovimientoCaja.DataSource = null;
            gcMovimientoCaja.RefreshDataSource();

            CargaMovimientosCajaDetalle();
            CalculaTotales();
        }

        private void gvMovimientoCaja_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoCaja.GetRow(e.RowHandle);

                DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["FlagEstado"]);
                    if (objDocRetiro != null)
                    {
                        int IdSituacion = (Convert.ToInt32(objDocRetiro.ToString()));
                        if (IdSituacion == 0)
                        {
                            e.Appearance.ForeColor = Color.Red;
                            e.Appearance.Font = new Font("Tahoma", 8, FontStyle.Regular | FontStyle.Strikeout);
                            //e.Appearance.ForeColor = Color.Gray;
                            //e.Appearance.BackColor = Color.Red;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        //else if (IdSituacion == 1)
                        //{
                        //    e.Appearance.BackColor = Color.Yellow;
                        //}
                        //else if (IdSituacion == "CANCELADO")
                        //{
                        //    e.Appearance.BackColor = Color.LightGreen;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            frmCierreCaja FrmCierre = new frmCierreCaja();

            FrmCierre.IdCajaEgreso = IdCajaEgreso;
            FrmCierre.SaldoIncial = ImporteSaldoInicial;

            FrmCierre.StartPosition = FormStartPosition.CenterParent;
            FrmCierre.ShowDialog();

            //if (FrmCierre.ShowDialog() == DialogResult.OK)
            //{
                this.Close();
            //}
        }

        private void verDocumentosAsociadoAlReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistroDocumentos objRegistroDocumentos = new frmRegistroDocumentos();
            
            objRegistroDocumentos.IdSituacionDocs = IdSituacion;
            objRegistroDocumentos.IdEmpresa = IdEmpresa;
            objRegistroDocumentos.IdCajaEgreso = IdCajaEgreso;
            objRegistroDocumentos.IdCajaEgresoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());
            objRegistroDocumentos.IdMoneda = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdMoneda").ToString());
            objRegistroDocumentos.Empresa = txtEmpresa.Text;
            objRegistroDocumentos.NumRecibo = gvMovimientoCaja.GetFocusedRowCellValue("NumRecibo").ToString();
            objRegistroDocumentos.NumDocumento = gvMovimientoCaja.GetFocusedRowCellValue("NumDocumento").ToString();
            objRegistroDocumentos.Nombres = gvMovimientoCaja.GetFocusedRowCellValue("Recibio").ToString();
            if (int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("TipoOperacion").ToString()) == 1)  //Ingreso
            {
                objRegistroDocumentos.MontoRecibo = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteIngreso").ToString());
            }
            else
            {
                objRegistroDocumentos.MontoRecibo = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteEgreso").ToString());
                objRegistroDocumentos.MontoDevolucion = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("ImporteDevuelto").ToString());
            }

            // objRegistroDocumentos.ImporteSaldoInicial = Convert.ToDecimal(gvMovimientoCaja.GetFocusedRowCellValue("SaldoInicial").ToString());

            objRegistroDocumentos.StartPosition = FormStartPosition.CenterParent;
            objRegistroDocumentos.ShowDialog();

            bsListado.Clear();
            gcMovimientoCaja.DataSource = null;
            gcMovimientoCaja.RefreshDataSource();

            CargaMovimientosCajaDetalle();
            CalculaTotales();
        }

        private void cboOperacion_TextChanged(object sender, EventArgs e)
        {
           if (Convert.ToInt32(cboOperacion.EditValue) == Parametros.intOperacionEgreso)
            {
                chkEgresoAdiconal.Visible = true;
            }
           else
            {
                chkEgresoAdiconal.Visible = false;
            }
        }

        private void checkRevisadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mCajaEgresoDetalleOrigen.Count > 0)
                {
                    bool FlagRevisa = bool.Parse(gvMovimientoCaja.GetFocusedRowCellValue("FlagRevisa").ToString());
                    if (FlagRevisa)
                    {
                        XtraMessageBox.Show("El registro fue revisado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        return;
                    }

                    bool flagRecibido = true;
                    FlagRevisa = bool.Parse(gvMovimientoCaja.GetFocusedRowCellValue("FlagRevisa").ToString());
                    if (!FlagRevisa)
                    {
                        CajaEgresoDetalleBL objBL_CajaEgresoDetalle = new CajaEgresoDetalleBL();
                        CajaEgresoDetalleBE objCajaEgresoDetalle = new CajaEgresoDetalleBE();

                        objCajaEgresoDetalle.IdCajaEgreso = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgreso").ToString());
                        objCajaEgresoDetalle.IdCajaEgresoDetalle = int.Parse(gvMovimientoCaja.GetFocusedRowCellValue("IdCajaEgresoDetalle").ToString());

                        //List<CambioDetalleBE> mCajaEgresoDetalleOrigen = null;
                        //mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);

                        objBL_CajaEgresoDetalle.ActualizaRevisa(objCajaEgresoDetalle);
                        gvMovimientoCaja.SetRowCellValue(gvMovimientoCaja.FocusedRowHandle, "FlagRevisa", true);
                        //  XtraMessageBox.Show("La solicitud de devolución se recibió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Cargar();
                        Cursor = Cursors.Default;

                    }
                    else
                    {
                        XtraMessageBox.Show("La solicitud de devolución esta recibida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                    }
                    Cursor = Cursors.Default;
                    //Cargar();
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