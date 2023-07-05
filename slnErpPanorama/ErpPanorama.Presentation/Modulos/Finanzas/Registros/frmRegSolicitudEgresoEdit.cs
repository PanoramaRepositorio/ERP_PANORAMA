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

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegSolicitudEgresoEdit: DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PrestamoBancoBE> lstPrestamoBanco;
        public List<CSolicitudEgresoDetalle> mListaPrestamoBancoDetalleOrigen = new List<CSolicitudEgresoDetalle>();
        public List<CuentaBancoBE> mListaCuentaBanco = new List<CuentaBancoBE>(); 
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        private int IdProveedor = 0;
        private int IdCliente=0;
        private string Usuario = "";
        public int IdSolicitudEgreso = 0;
        public int IdSolicitudEgresoDetalle = 0;
        public string NumeroGenerado = "";
        public int CantidadDet = 0;
        //public string NumeroSolicitudEgreso = "";
        public Operacion pOperacion { get; set; }

        public int IdCuentaBanco = 0;

        int _IdPrestamoBanco = 0;

        public int IdPrestamoBanco
        {
            get { return _IdPrestamoBanco; }
            set { _IdPrestamoBanco = value; }
        }
        private int NumCar = 0;
        #endregion

        #region "Eventos"
        public frmRegSolicitudEgresoEdit()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudEgresoEdit_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboCuentaBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            cboFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboCentroCosto, new TablaBL().ListaTodosActivoCentroCosto(Parametros.intEmpresaId), "DescTabla", "IdTabla", true);
            cboCentroCosto.EditValue = 86;
            BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId,Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);

            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosTiendasActivo2(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboAsignar.EditValue = 15;
            //BSUtils.LoaderLook(cboTipoPrestamo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoPrestamo), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboSolicitante, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            cboSolicitante.EditValue = Parametros.intPersonaId;
            //CargarCombo
            if (pOperacion == Operacion.Nuevo)
            { cboCentroCosto_EditValueChanged(null, null); }
            BSUtils.LoaderLook(cboTipoEgreso, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 89), "DescTablaElemento", "IdTablaElemento", true);
            //cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboProcedencia, CargaProcedencia(), "Descripcion", "Id", false);
            cboProcedencia.EditValue = "";
            if (pOperacion == Operacion.Nuevo)
            {
                CargarCombo();

                this.Text = "Solicitud - Nuevo";
                //cboCuentaBanco.EditValue = IdCuentaBanco;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Solicitud - Editar";

                SolicitudEgresoBE objE_Solicitud = null;
                objE_Solicitud = new SolicitudEgresoBL().Buscar_SolicitudEgreso(IdSolicitudEgreso);

                Usuario = objE_Solicitud.Usuario;

                txtSolicitudEgreso.Text = objE_Solicitud.NumSolicitudEgreso;
                cboFecha.EditValue = objE_Solicitud.FechaSolicitudEgreso;
                cboMoneda.EditValue = objE_Solicitud.IdMoneda;
                cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;

                txtNumeroDocumento.Text = objE_Solicitud.NumeroDocumento;
                txtDescProveedor.Text = objE_Solicitud.DescProveedor;
                IdProveedor = objE_Solicitud.IdProveedor;

                cboTienda.EditValue = objE_Solicitud.IdTienda;
                cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;
                //////
                BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(objE_Solicitud.IdProveedor, Convert.ToInt32(objE_Solicitud.IdMoneda)), "DescBanco", "IdCuentaBancoProveedor", true);

                //CuentaBancoBE objBE_CuentaBancoProveedor = null;
                //objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(objE_Solicitud.IdBanco));
                //if (objBE_CuentaBancoProveedor != null)
                //{
                //    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                //}
                IdCliente = objE_Solicitud.IdCliente;

                cboCuentaBancoProveedor.EditValue = objE_Solicitud.IdBanco;
                txtCuenta.Text = objE_Solicitud.Cuenta;
                txtCCI.Text = objE_Solicitud.CCI;
                txtDescSolicitud.Text = objE_Solicitud.DescSolicitudEgreso;
                cboSolicitante.EditValue = objE_Solicitud.IdPersona;
                cboTipoEgreso.EditValue = objE_Solicitud.IdTipoEgreso;
                txtOC.Text = objE_Solicitud.NumOCompra;
                txtObs.Text = objE_Solicitud.Obs;

                speAbonoInicio.Value = Convert.ToInt32(objE_Solicitud.NroAbonoInicio);
                speFin.Value = Convert.ToInt32(objE_Solicitud.NroAbonoFin);
                txtAFacturar.Text = objE_Solicitud.RazonSocialFactura;
                txtCuentaContable.Text = objE_Solicitud.CuentaContable.Trim();
                txtTipoCambio.Text =(objE_Solicitud.TCambio).ToString();

                cboProcedencia.EditValue = objE_Solicitud.Procedencia;
            }
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text = "Solicitud - Consulta";

                SolicitudEgresoBE objE_Solicitud = null;
                objE_Solicitud = new SolicitudEgresoBL().Buscar_SolicitudEgreso(IdSolicitudEgreso);

                txtSolicitudEgreso.Text = objE_Solicitud.NumSolicitudEgreso;
                cboFecha.EditValue = objE_Solicitud.FechaSolicitudEgreso;
                cboMoneda.EditValue = objE_Solicitud.IdMoneda;
                cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;

                txtNumeroDocumento.Text = objE_Solicitud.NumeroDocumento;
                txtDescProveedor.Text = objE_Solicitud.DescProveedor;
                IdProveedor = objE_Solicitud.IdProveedor;

                cboTienda.EditValue = objE_Solicitud.IdTienda;
                cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;
                //////
                BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(objE_Solicitud.IdProveedor, Convert.ToInt32(objE_Solicitud.IdMoneda)), "DescBanco", "IdCuentaBancoProveedor", true);

                IdCliente = objE_Solicitud.IdCliente;

                cboCuentaBancoProveedor.EditValue = objE_Solicitud.IdBanco;
                txtCuenta.Text = objE_Solicitud.Cuenta;
                txtCCI.Text = objE_Solicitud.CCI;
                txtDescSolicitud.Text = objE_Solicitud.DescSolicitudEgreso;
                cboSolicitante.EditValue = objE_Solicitud.IdPersona;
                cboTipoEgreso.EditValue = objE_Solicitud.IdTipoEgreso;
                txtOC.Text = objE_Solicitud.NumOCompra;
                txtObs.Text = objE_Solicitud.Obs;

                speAbonoInicio.Value = Convert.ToInt32(objE_Solicitud.NroAbonoInicio);
                speFin.Value = Convert.ToInt32(objE_Solicitud.NroAbonoFin);
                txtAFacturar.Text = objE_Solicitud.RazonSocialFactura;

                txtCuentaContable.Text = objE_Solicitud.CuentaContable.Trim();
                txtTipoCambio.Text = (objE_Solicitud.TCambio).ToString();

                btnGrabar.Enabled = false;
                simpleButton1.Enabled = false;
                simpleButton2.Enabled = false;
                cboTipoEgreso.Enabled = false;
                cboSolicitante.Enabled = false;
                cboAsignar.Enabled = false;
                cboMoneda.Enabled = false;
                cboCuentaBancoProveedor.Enabled = false;
                cboCentroCosto.ReadOnly = true;
                cboTienda.ReadOnly = true;
                txtDescProveedor.ReadOnly = true;
                txtOC.ReadOnly = true;
                txtSolicitudEgreso.ReadOnly = true;
                txtCuenta.ReadOnly = true;
                txtCCI.ReadOnly = true;
                txtDescSolicitud.ReadOnly = true;
                txtObs.ReadOnly = true;
                txtAFacturar.ReadOnly = true;
                txtNumeroDocumento.ReadOnly = true;
                speFin.ReadOnly = true;
                txtCuentaContable.ReadOnly = true;

                cboProcedencia.EditValue = objE_Solicitud.Procedencia;
            }

            CargaPrestamoBancoDetalle();
            CantidadDet = gvPrestamoBancoDetalle.RowCount;
        }

        private DataTable CargaProcedencia()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "NACIONAL";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "EXTRANJERO";
            dt.Rows.Add(dr);

            return dt;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
              
                    Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    SolicitudEgresoBL objBL_SolicitudEgreso = new SolicitudEgresoBL();
                    SolicitudEgresoBE objSolicitudEgreso = new SolicitudEgresoBE();

                    objSolicitudEgreso.IdSolicitudEgreso = IdSolicitudEgreso;
                    objSolicitudEgreso.NumSolicitudEgreso = txtSolicitudEgreso.Text.Trim();
                    objSolicitudEgreso.FechaSolicitudEgreso = Convert.ToDateTime(cboFecha.DateTime.ToShortDateString());
                    objSolicitudEgreso.DescSolicitudEgreso = txtDescSolicitud.Text.Trim();
                    objSolicitudEgreso.IdProveedor = IdProveedor;
                    objSolicitudEgreso.IdBanco = Convert.ToInt32(cboCuentaBancoProveedor.EditValue);
                    objSolicitudEgreso.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objSolicitudEgreso.IdPersona = Convert.ToInt32(cboSolicitante.EditValue);
                    objSolicitudEgreso.NumOCompra = txtOC.Text.Trim();
                    objSolicitudEgreso.NroAbonoInicio = Convert.ToInt32(speAbonoInicio.Value);
                    objSolicitudEgreso.NroAbonoFin = Convert.ToInt32(speFin.Value);
                    objSolicitudEgreso.IdTipoEgreso = Convert.ToInt32(cboTipoEgreso.EditValue);
                    objSolicitudEgreso.IdTienda = Convert.ToInt32(cboTienda.EditValue);

                    objSolicitudEgreso.IdCliente = IdCliente;
                    objSolicitudEgreso.RazonSocialFactura = txtAFacturar.Text.Trim();

                    objSolicitudEgreso.IdCentroCosto = Convert.ToInt32(cboCentroCosto.EditValue);
                    objSolicitudEgreso.IdDetalleCentroCosto = Convert.ToInt32(cboAsignar.EditValue);
                    objSolicitudEgreso.Obs = txtObs.Text.Trim();
                    objSolicitudEgreso.Usuario = Usuario==""? Parametros.strUsuarioLogin : Usuario ;
                    objSolicitudEgreso.IdSituacion = 1;
                    objSolicitudEgreso.CuentaContable = txtCuentaContable.Text.Trim();
                    objSolicitudEgreso.TCambio = Convert.ToDecimal(txtTipoCambio.Text);

                    //Solicitud Egreso detalle
                    Decimal vMontoTotal =0;
                    List<SolicitudEgresoDetalleBE> lstListaSolicitudEgresoDetalle = new List<SolicitudEgresoDetalleBE>();

                    foreach(var item in mListaPrestamoBancoDetalleOrigen)
                    {
                        SolicitudEgresoDetalleBE objE_SolicitudEgresoDetalle = new SolicitudEgresoDetalleBE();


                            objE_SolicitudEgresoDetalle.IdSolicitudEgresoDetalle = item.IdSolicitudEgresoDetalle;
                            objE_SolicitudEgresoDetalle.IdSolicitudEgreso = IdSolicitudEgreso;
                            objE_SolicitudEgresoDetalle.NumeroAbono = item.NumAbono;
                            objE_SolicitudEgresoDetalle.MontoAbono = item.Monto;

                            if (Convert.ToDateTime(item.FechaPagoSolicitada2) is Nullable || Convert.ToDateTime(item.FechaPagoSolicitada2)==Convert.ToDateTime("01/01/0001"))
                            {
                                XtraMessageBox.Show("Ingrese la(s) fecha(s) de solicitud de pago para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            else
                            {
                                objE_SolicitudEgresoDetalle.FechaPagoSolicitada = item.FechaPagoSolicitada2;
                            }

                            objE_SolicitudEgresoDetalle.FlagEstado = true;
                            objE_SolicitudEgresoDetalle.TipoOper = CantidadDet==0? 1: item.TipoOper;

                        vMontoTotal = vMontoTotal + item.Monto;
               
                        lstListaSolicitudEgresoDetalle.Add(objE_SolicitudEgresoDetalle);
                    }

                    objSolicitudEgreso.Total = vMontoTotal;


                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_SolicitudEgreso.Inserta(objSolicitudEgreso, lstListaSolicitudEgresoDetalle);
                    }
                    else
                    {
                        objBL_SolicitudEgreso.Actualiza(objSolicitudEgreso, lstListaSolicitudEgresoDetalle);
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegPrestamoBancoEdit_Shown(object sender, EventArgs e)
        {
            NumCar = 1;
            bool bolFlag = false;

            TipoCambioBE objE_TipoCambio = null;
            objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);
            if (objE_TipoCambio == null)
            {
                //XtraMessageBox.Show("Falta ingresar Tipo de Cambio del Día", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //bolFlag = true;
            }
            else
            {
                if (pOperacion == Operacion.Nuevo)
                {
                    txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Venta.ToString());
                }
            }

            if (bolFlag)
            {
                this.Close();
            }
        }

        private void cboCuentaBanco_EditValueChanged(object sender, EventArgs e)
        {
            //if (pOperacion == Operacion.Nuevo)
            //{
            //    if (cboCuentaBanco.EditValue.ToString() != "0")
            //    {
            //        if (NumCar == 1)
            //        {
            //            var item = cboCuentaBanco.GetSelectedDataRow() as CuentaBancoBE;
            //            if (item.IdCuentaBanco > 0)
            //            {
            //                IdCuentaBanco = item.IdCuentaBanco;
            //                txtNumeroCuenta.Text = item.NumeroCuenta.ToString();
            //                cboMoneda.EditValue = item.IdMoneda;
            //            }
            //            else
            //            {
            //                IdCuentaBanco = 0;
            //                txtNumeroCuenta.Text = "";
            //            }
            //        }
            //    }
            //}
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
                int IdSituacion = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
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

                        int IdPrestamoBancoDetalle = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                        objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                        objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                        objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoCancelado;
                        objE_PrestamoBancoDetalle.FechaPago = frm.Fecha;
                        objE_PrestamoBancoDetalle.Usuario = frmAutoriza.Usuario;//Parametros.strUsuarioLogin;
                        objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "DescSituacion", "CANCELADO");
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoCancelado);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaPago", frm.Fecha);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "UsuarioPago", frmAutoriza.Usuario);//Parametros.strUsuarioLogin);

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
                    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Monto"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));


                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
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
            if (e.KeyCode == Keys.Enter)
            {
                if (pOperacion == Operacion.Nuevo)
                {
                    int nCuotas = 0;
                    nCuotas = Convert.ToInt32(speFin.Value);  // txtCuotas.EditValue
                    if (nCuotas > 0)
                    {
                        for (int i = 1; i <= nCuotas; i++)
                        {
                            gvPrestamoBancoDetalle.AddNewRow();
                            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumeroCuota", i);
                        }
                    }
                }
            }
        }

        private void habilitarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
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

                    int IdPrestamoBancoDetalle = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                    objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                    objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                    objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoPendiente;
                    objE_PrestamoBancoDetalle.FechaPago = null;
                    objE_PrestamoBancoDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "DescSituacion", "PENDIENTE");
                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoPendiente);
                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaPago", null);
                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "UsuarioPago", Parametros.strUsuarioLogin);

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

            //if (IdCuentaBanco == 0)
            //{
            //    strMensaje = strMensaje + "- Selecione el banco.\n";
            //    flag = true;
            //}

            if (txtDescProveedor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el proveedor de la solicitud.\n";
                flag = true;
            }

            if (txtDescSolicitud.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción de la solicitud.\n";
                flag = true;
            }


            if (txtAFacturar.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la razón social a facturar.\n";
                flag = true;
            }
            

            //if (deFecha.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese Fecha.\n";
            //    flag = true;
            //}

            //if (deFechaVencimiento.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese Fecha de Vencimiento.\n";
            //    flag = true;
            //}

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Selecione el tipo de moneda.\n";
                flag = true;
            }

            if (cboTipoEgreso.EditValue.ToString() == "0")
            {
                strMensaje = strMensaje + "- Selecione el tipo de egreso.\n";
                flag = true;
            }

            //if (cboTipoEgreso.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Selecione el tipo de moneda.\n";
            //    flag = true;
            //}



            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstPrestamoBanco.Where(oB => oB.IdMoneda == Convert.ToInt32(cboMoneda.EditValue) && oB.NumeroPrestamo == txtNumeroPrestamo.Text).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- El número de Prestamo ya existe.\n";
            //        flag = true;
            //    }

            //    if (Convert.ToDecimal(txtPrestamo.EditValue)<=0)
            //    {
            //        strMensaje = strMensaje + "- Ingrese el Total de préstamo.\n";
            //        flag = true;
            //    }

            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CargaPrestamoBancoDetalle()
        {
            List<SolicitudEgresoDetalleBE> lstTmpPrestamoBancoDetalle = null;
            lstTmpPrestamoBancoDetalle = new SolicitudEgresoDetalleBL().ListaTodosActivo(IdSolicitudEgreso);

            foreach (SolicitudEgresoDetalleBE item in lstTmpPrestamoBancoDetalle)
            {
                CSolicitudEgresoDetalle objE_SolicitudEgresoDetalle = new CSolicitudEgresoDetalle();

                objE_SolicitudEgresoDetalle.IdSolicitudEgreso = item.IdSolicitudEgreso;
                objE_SolicitudEgresoDetalle.IdSolicitudEgresoDetalle = item.IdSolicitudEgresoDetalle;
                objE_SolicitudEgresoDetalle.NumAbono = item.NumeroAbono;
                objE_SolicitudEgresoDetalle.FechaPagoSolicitada2 =Convert.ToDateTime( item.FechaPagoSolicitada);
                objE_SolicitudEgresoDetalle.Monto = item.MontoAbono;

                objE_SolicitudEgresoDetalle.TipoOper = Convert.ToInt32(Operacion.Consultar);

                mListaPrestamoBancoDetalleOrigen.Add(objE_SolicitudEgresoDetalle);
            }

            bsListado.DataSource = mListaPrestamoBancoDetalleOrigen;
            gcPrestamoBancoDetalle.DataSource = bsListado;
            gcPrestamoBancoDetalle.RefreshDataSource();

            lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
        }

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


                    if (pOperacion == Operacion.Nuevo)
                    {
                        gvPrestamoBancoDetalle.AddNewRow();
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdPrestamoBanco", IdPrestamoBanco);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdPrestamoBancoDetalle", 0);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumeroCuota", NumeroCuota);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaVencimiento", FechaVencimiento);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "SaldoPendiente", SaldoPendiente);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Amortizacion", Amortizacion);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Interes", Interes);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Desgravamen", Desgravamen);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Seguro", Seguro);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TotalPagar", TotalPagar);
                        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FlagEstado", true);
                        if (pOperacion == Operacion.Modificar)
                            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

                        TotalAgregado = TotalAgregado + 1;
                    }

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

                //txtSaldoPrestamo.EditValue = decAmortizacion;
                //txtSaldoInteres.EditValue = decTotalInteres;
                //txtInteres.EditValue = decInteres;
                //txtCuotas.EditValue = intCuotas;
                //deFechaVencimiento.EditValue = FechaVen;
                //txtNumeroPrestamo.Text = sNumeroPrestamo;
                lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";



                XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                xlLibro.Close(false, Missing.Value, Missing.Value);
                xlApp.Quit();
                if (pOperacion == Operacion.Modificar)
                {
                    this.Close();
                }
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

                for (int i = 0; i < gvPrestamoBancoDetalle.RowCount; i++)
                {
                    intSituacion = Convert.ToInt32(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["IdSituacion"])));

                    decSaldo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["SaldoPendiente"])));
                    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["Interes"])));

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

        public class CSolicitudEgresoDetalle
        {
            //public Int32 IdEmpresa { get; set; }
            public Int32 IdSolicitudEgreso { get; set; }
            public Int32 IdSolicitudEgresoDetalle { get; set; }
            public Int32 NumAbono { get; set; }
            public DateTime FechaPagoSolicitada { get; set; }
            public DateTime FechaPagoSolicitada2 { get; set; }
            public Decimal Monto { get; set; }
            //public Decimal SaldoPendiente { get; set; }
            //public Decimal Amortizacion { get; set; }
            //public Decimal Interes { get; set; }
            //public Decimal EnvioInformacion { get; set; }
            //public Decimal Desgravamen { get; set; }
            //public Decimal Seguro { get; set; }
            //public Decimal TotalPagar { get; set; }
            //public Int32  IdSituacion { get; set; }
            //public String DescSituacion { get; set; }
            //public DateTime? FechaPago { get; set; }
            //public String UsuarioPago { get; set; }
            public Boolean FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }

            public CSolicitudEgresoDetalle()
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           if (pOperacion == Operacion.Modificar)
               {
                if (gvPrestamoBancoDetalle.RowCount > 0)
                {
                    if (XtraMessageBox.Show("¿Esta seguro de generar nuevamente los abonos? Esto borra los abonos anteriores.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SolicitudEgresoBE objSolicitudEgreso = new SolicitudEgresoBE();
                        SolicitudEgresoBL objBL_SolicitudEgreso = new SolicitudEgresoBL();
                        objSolicitudEgreso.IdSolicitudEgreso = IdSolicitudEgreso;
                        objBL_SolicitudEgreso.Elimina(objSolicitudEgreso);

                        gvPrestamoBancoDetalle.Focus();
                        gvPrestamoBancoDetalle.SelectAll();
                        gvPrestamoBancoDetalle.DeleteSelectedRows();

                        int nCuotas = 0;
                        nCuotas = Convert.ToInt32(speFin.Value);
                        if (nCuotas > 0)
                        {
                            for (int i = 1; i <= nCuotas; i++)
                            {
                                gvPrestamoBancoDetalle.AddNewRow();
                                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumAbono", i);
                                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", 1);
                            }
                        }

                    }
                }
                else
                {
                    gvPrestamoBancoDetalle.Focus();
                    gvPrestamoBancoDetalle.SelectAll();
                    gvPrestamoBancoDetalle.DeleteSelectedRows();

                    //if (pOperacion == Operacion.Nuevo)
                    //{
                        int nCuotas = 0;
                        nCuotas = Convert.ToInt32(speFin.Value);
                        if (nCuotas > 0)
                        {
                            for (int i = 1; i <= nCuotas; i++)
                            {
                                gvPrestamoBancoDetalle.AddNewRow();
                                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumAbono", i);
                            }
                        }
                    //}

                }
               }
            else
            {
                gvPrestamoBancoDetalle.Focus();
                gvPrestamoBancoDetalle.SelectAll();
                gvPrestamoBancoDetalle.DeleteSelectedRows();

                if (pOperacion == Operacion.Nuevo)
                {
                    int nCuotas = 0;
                    nCuotas = Convert.ToInt32(speFin.Value);
                    if (nCuotas > 0)
                    {
                        for (int i = 1; i <= nCuotas; i++)
                        {
                            gvPrestamoBancoDetalle.AddNewRow();
                            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumAbono", i);
                        }
                    }
                }
            }
        }

        private void cboAsignar_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCentroCosto_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                    {
                        ProveedorBE objE_Proveedor = null;
                        objE_Proveedor = new ProveedorBL().SeleccionaNumero(txtNumeroDocumento.Text.Trim());
                        if (objE_Proveedor != null)
                        {
                            IdProveedor = objE_Proveedor.IdProveedor;
                            txtNumeroDocumento.Text = objE_Proveedor.NumeroDocumento.Trim();
                            txtDescProveedor.Text = objE_Proveedor.DescProveedor.Trim();
                           // BSUtils.LoaderLook(cboProcedencia, CargaProcedencia(), "Descripcion", "Id", false);
                            cboProcedencia.EditValue = objE_Proveedor.Procedencia;

                            //Bloquear Ruc
                            //   txtNumeroDocumento.Properties.ReadOnly = true;                    

                            BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

                            CuentaBancoBE objBE_CuentaBancoProveedor = null;
                            objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
                            if (objBE_CuentaBancoProveedor != null)
                            {
                                txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                            }

                            //cboCuentaBancoProveedor.EditValue = Parametros.intSoles;
                        }
                        else
                        {
                            XtraMessageBox.Show("El proveedor no existe, debera registrarlo antes de continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        btnBuscar_Click(sender, e);
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
                frmBusProveedor frm = new frmBusProveedor();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pProveedorBE != null)
                {

                    IdProveedor = frm.pProveedorBE.IdProveedor;
                    txtNumeroDocumento.Text = frm.pProveedorBE.NumeroDocumento;
                    txtDescProveedor.Text = frm.pProveedorBE.DescProveedor;
                    cboProcedencia.EditValue = frm.pProveedorBE.Procedencia;
                }

                BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

                CuentaBancoBE objBE_CuentaBancoProveedor = null;
                objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
                if (objBE_CuentaBancoProveedor != null)
                {
                    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCuentaBancoProveedor_EditValueChanged(object sender, EventArgs e)
        {
            CuentaBancoBE objBE_CuentaBancoProveedor = null;
            objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
            if (objBE_CuentaBancoProveedor != null)
            {
                txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                txtCCI.EditValue = objBE_CuentaBancoProveedor.CCI;
            }
            else
            {
                txtCuenta.EditValue = "";
                txtCCI.EditValue = "";
            }
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtCuenta.EditValue = "";
                cboCuentaBancoProveedor.EditValue=0;
                BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

                CuentaBancoBE objBE_CuentaBancoProveedor = null;
                objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
                if (objBE_CuentaBancoProveedor != null)
                {
                    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                    txtCCI.EditValue = objBE_CuentaBancoProveedor.CCI;
                }
                else
            {
                    txtCuenta.EditValue = "";
                    txtCCI.EditValue = "";
                }
            }
            catch (Exception ex)
            {
               // XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTipoEgreso_EditValueChanged(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                if (Convert.ToInt32(cboTipoEgreso.EditValue) == 518)
                {
                    IdCliente = 236149;
                    txtAFacturar.Text = "DECORATEX E.I.R.L.";
                }
                else if (Convert.ToInt32(cboTipoEgreso.EditValue) == 519)
                {
                    IdCliente = 236149;
                    txtAFacturar.Text = "DECORATEX E.I.R.L.";
                }
                else if (Convert.ToInt32(cboTipoEgreso.EditValue) == 520)
                {
                    IdCliente = 0;
                    txtAFacturar.Text = "";
                }
                else if (Convert.ToInt32(cboTipoEgreso.EditValue) == 521)
                {
                    IdCliente = 0;
                    txtAFacturar.Text = "";
                }
            }
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
                    txtAFacturar.Text = frm.pClienteBE.DescCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}