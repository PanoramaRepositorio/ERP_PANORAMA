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
    public partial class frmRegCuentasPorPagarEdit : DevExpress.XtraEditors.XtraForm
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
        public Operacion pOperacion { get; set; }

        private int IdProveedor = 0;
        private int IdCliente = 0;
        private string Usuario = "";
        public int IdSolicitudEgreso = 0;
        public int IdSolicitudEgresoDetalle = 0;
        public int CantidadDet = 0;

        public int IdSituacion = 0;
        public string NumeroGenerado = "";
        public DateTime FechaBloque = default(DateTime);
        public string IndiceBloque = "";

        // EDGAR 250123: AGREGAR 
        public int IdCuentaPagar = 0;
        //public string NumeroSolicitudEgreso = "";

        public int IdCuentaBanco = 0;
        int _IdPrestamoBanco = 0;

        public decimal ImporteSoles = 0;
        public decimal ImporteDolares = 0;

        public decimal Importe = 0;
        public decimal MontoAbono = 0;
        public decimal TCambio = 0;
        public Int32 Moneda = 0;
        public decimal Saldo = 0;

        private Boolean flag_txtImporte = false;
        private Boolean flag_cboTipoBien = false;
        private Boolean flag_cboMoneda = false;
        private Boolean flag_dteFechaEmision = false;

        public int IdPrestamoBanco
        {
            get { return _IdPrestamoBanco; }
            set { _IdPrestamoBanco = value; }
        }
        private int NumCar = 0;
        #endregion

        #region "Eventos"
        public frmRegCuentasPorPagarEdit()
        {
            flag_txtImporte = true;
            flag_cboTipoBien = true;
            flag_cboMoneda = true;
            flag_dteFechaEmision = true;

            InitializeComponent();
        }

        private void frmRegCuentasPorPagarEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoOperacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 96), "DescTablaElemento", "IdTablaElemento", true);
            cboTipoOperacion.EditValue = 603;
            BSUtils.LoaderLook(cboTipoBien, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 95), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboCentroCosto, new TablaBL().ListaTodosActivoCentroCosto(Parametros.intEmpresaId), "DescTabla", "IdTabla", true);
            cboCentroCosto.EditValue = 86;
            BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);

            BSUtils.LoaderLook(cboTipoDocumento, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 91), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;

            dteFechaEmision.EditValue = DateTime.Now;
            dteFechaVenc.EditValue = dteFechaEmision.DateTime.AddDays(30);


            if (pOperacion == Operacion.Nuevo)
            {
                //cboCentroCosto_EditValueChanged(null, null);
                cboTipoDocumento.EditValue = 541;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                CargarCombo();

                this.Text = "Nuevo Documento";
                IdSituacion = Parametros.intSitPendienteCon;
                //IdSituacion = 403;
                //cboCuentaBanco.EditValue = IdCuentaBanco;
                //Importe = txtImporte.EditValue == null || txtImporte.EditValue.ToString() == "" ? 0 : Convert.ToDecimal(txtImporte.EditValue);
                //MontoAbono = txtMontoAbono.EditValue == null || txtMontoAbono.EditValue.ToString()  == "" ? 0 : Convert.ToDecimal(txtMontoAbono.EditValue);
                //TC = Convert.ToDecimal(txtTipoCambio.EditValue);
            }
            else if (pOperacion == Operacion.Modificar)
            {
                // EDGAR 250123: AGREGAR VALORES EN CAMPOS PARA EDITAR 
                this.Text = "Editar Documento";

                CuentaPorPagarBE obj_ECuenta = null;
                obj_ECuenta = new CuentaPorPagarBL().Buscar_CuentaPorPagar(IdCuentaPagar);

                //Usuario = objE_Solicitud.Usuario;
                IdProveedor = obj_ECuenta.IdProveedor;

                cboTipoOperacion.EditValue = obj_ECuenta.IdTipoOperacion;
                cboTipoBien.EditValue = obj_ECuenta.IdBienServicio;
                cboCentroCosto.EditValue = obj_ECuenta.IdCentroCosto;
                BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
                cboAsignar.EditValue = obj_ECuenta.IdAsignar;
                cboTipoDocumento.EditValue = obj_ECuenta.IdTipoDocumento;
                cboMoneda.EditValue = obj_ECuenta.IdMoneda;

                dteFechaEmision.EditValue = obj_ECuenta.FechaDoc;
                dteFechaVenc.EditValue = obj_ECuenta.FechaVencimiento;

                txtSerie.Text = obj_ECuenta.Serie;
                txtNumFactura.Text = obj_ECuenta.Numero.ToString();
                txtNumeroDocumento.Text = obj_ECuenta.RucProveedor;
                txtDescProveedor.Text = obj_ECuenta.NombreProveedor;
                txtImporte.Text = obj_ECuenta.Importe.ToString();
                txtMontoAbono.Text = obj_ECuenta.MontoAbono.ToString();
                txtTipoCambio.Text = obj_ECuenta.TCambio.ToString();
                txtCuentaBN.Text = obj_ECuenta.CuentaBN.ToString();
                txtCuentaProv.Text = obj_ECuenta.CuentaProv.ToString();
                txtGlosa.Text = obj_ECuenta.Observacion;
                IdSituacion = obj_ECuenta.IdSituacion;
                FechaBloque = obj_ECuenta.fechaBloque;
                NumeroGenerado = obj_ECuenta.NumeroBloque;
                IndiceBloque = obj_ECuenta.IndiceBloque;
                
                //ImporteSoles = obj_ECuenta.Importe;
                ImporteDolares = obj_ECuenta.ImporteDolares;
                Saldo = obj_ECuenta.Saldo;
                //if (obj_ECuenta.IdMoneda == 5)
                //    txtImporte.Text = ImporteSoles.ToString();
                //else if (obj_ECuenta.IdMoneda == 6)
                //    txtImporte.Text = ImporteDolares.ToString();

                #region codigo anterior comentado
                //this.Text = "Editar Documento";

                //SolicitudEgresoBE objE_Solicitud = null;
                //objE_Solicitud = new SolicitudEgresoBL().Buscar_SolicitudEgreso(IdSolicitudEgreso);

                //Usuario = objE_Solicitud.Usuario;

                //txtSolicitudEgreso.Text = objE_Solicitud.NumSolicitudEgreso;
                //cboFecha.EditValue = objE_Solicitud.FechaSolicitudEgreso;
                //cboMoneda.EditValue = objE_Solicitud.IdMoneda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;

                //txtNumeroDocumento.Text = objE_Solicitud.NumeroDocumento;
                //txtDescProveedor.Text = objE_Solicitud.DescProveedor;
                //IdProveedor = objE_Solicitud.IdProveedor;

                //cboTienda.EditValue = objE_Solicitud.IdTienda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;
                ////////
                //BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(objE_Solicitud.IdProveedor, Convert.ToInt32(objE_Solicitud.IdMoneda)), "DescBanco", "IdCuentaBancoProveedor", true);

                //IdCliente = objE_Solicitud.IdCliente;

                //cboCuentaBancoProveedor.EditValue = objE_Solicitud.IdBanco;
                //txtCuenta.Text = objE_Solicitud.Cuenta;
                //txtCCI.Text = objE_Solicitud.CCI;
                //txtDescSolicitud.Text = objE_Solicitud.DescSolicitudEgreso;
                //cboSolicitante.EditValue = objE_Solicitud.IdPersona;
                //cboTipoEgreso.EditValue = objE_Solicitud.IdTipoEgreso;
                //txtOC.Text = objE_Solicitud.NumOCompra;
                //txtObs.Text = objE_Solicitud.Obs;

                //speAbonoInicio.Value = Convert.ToInt32(objE_Solicitud.NroAbonoInicio);
                //speFin.Value = Convert.ToInt32(objE_Solicitud.NroAbonoFin);
                //txtAFacturar.Text = objE_Solicitud.RazonSocialFactura;
                //txtCuentaContable.Text = objE_Solicitud.CuentaContable.Trim();
                //txtTipoCambio.Text =(objE_Solicitud.TCambio).ToString();
                #endregion
            }
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text = "Consulta";

                CuentaPorPagarBE obj_ECuenta = null;
                obj_ECuenta = new CuentaPorPagarBL().Buscar_CuentaPorPagar(IdCuentaPagar);

                //Usuario = objE_Solicitud.Usuario;
                IdProveedor = obj_ECuenta.IdProveedor;

                cboTipoOperacion.EditValue = obj_ECuenta.IdTipoOperacion;
                cboTipoBien.EditValue = obj_ECuenta.IdBienServicio;
                cboCentroCosto.EditValue = obj_ECuenta.IdCentroCosto;
                BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);
                cboAsignar.EditValue = obj_ECuenta.IdAsignar;
                cboTipoDocumento.EditValue = obj_ECuenta.IdTipoDocumento;
                cboMoneda.EditValue = obj_ECuenta.IdMoneda;

                dteFechaEmision.EditValue = obj_ECuenta.FechaDoc;
                dteFechaVenc.EditValue = obj_ECuenta.FechaVencimiento;

                txtSerie.Text = obj_ECuenta.Serie;
                txtNumFactura.Text = obj_ECuenta.Numero.ToString();
                txtNumeroDocumento.Text = obj_ECuenta.RucProveedor;
                txtDescProveedor.Text = obj_ECuenta.NombreProveedor;
                txtImporte.Text = obj_ECuenta.Importe.ToString();
                txtMontoAbono.Text = obj_ECuenta.MontoAbono.ToString();
                txtTipoCambio.Text = obj_ECuenta.TCambio.ToString();
                txtCuentaBN.Text = obj_ECuenta.CuentaBN.ToString();
                txtCuentaProv.Text = obj_ECuenta.CuentaProv.ToString();
                txtGlosa.Text = obj_ECuenta.Observacion;
                IdSituacion = obj_ECuenta.IdSituacion;
                FechaBloque = obj_ECuenta.fechaBloque;
                NumeroGenerado = obj_ECuenta.NumeroBloque;
                IndiceBloque = obj_ECuenta.IndiceBloque;

                //ImporteSoles = obj_ECuenta.Importe;
                ImporteDolares = obj_ECuenta.ImporteDolares;
                Saldo = obj_ECuenta.Saldo;
                //if (obj_ECuenta.IdMoneda == 5)
                //    txtImporte.Text = ImporteSoles.ToString();
                //else if (obj_ECuenta.IdMoneda == 6)
                //    txtImporte.Text = ImporteDolares.ToString();


                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
                btnBuscar.Enabled = false;

                cboTipoOperacion.ReadOnly = true;
                cboTipoBien.ReadOnly = true;
                cboCentroCosto.ReadOnly = true;
                cboTipoDocumento.ReadOnly = true;
                cboAsignar.ReadOnly = true;
                cboMoneda.ReadOnly = true;

                txtDescProveedor.ReadOnly = true;
                txtNumeroDocumento.ReadOnly = true;
                txtNumFactura.ReadOnly = true;
                txtSerie.ReadOnly = true;
                txtTipoCambio.ReadOnly = true;
                txtImporte.ReadOnly = true;
                txtMontoAbono.ReadOnly = true;
                txtGlosa.ReadOnly = true;
                txtCuentaBN.ReadOnly = true;
                txtCuentaProv.ReadOnly = true;

                dteFechaEmision.ReadOnly = true;
                dteFechaVenc.ReadOnly = true;

                #region codigo anterior comentado
                //SolicitudEgresoBE objE_Solicitud = null;
                //objE_Solicitud = new SolicitudEgresoBL().Buscar_SolicitudEgreso(IdSolicitudEgreso);

                //txtSolicitudEgreso.Text = objE_Solicitud.NumSolicitudEgreso;
                //cboFecha.EditValue = objE_Solicitud.FechaSolicitudEgreso;
                //cboMoneda.EditValue = objE_Solicitud.IdMoneda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;

                //txtNumeroDocumento.Text = objE_Solicitud.NumeroDocumento;
                //txtDescProveedor.Text = objE_Solicitud.DescProveedor;
                //IdProveedor = objE_Solicitud.IdProveedor;

                //cboTienda.EditValue = objE_Solicitud.IdTienda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;
                ////////
                //BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(objE_Solicitud.IdProveedor, Convert.ToInt32(objE_Solicitud.IdMoneda)), "DescBanco", "IdCuentaBancoProveedor", true);

                //IdCliente = objE_Solicitud.IdCliente;

                //cboCuentaBancoProveedor.EditValue = objE_Solicitud.IdBanco;
                //txtCuenta.Text = objE_Solicitud.Cuenta;
                //txtCCI.Text = objE_Solicitud.CCI;
                //txtDescSolicitud.Text = objE_Solicitud.DescSolicitudEgreso;
                //cboSolicitante.EditValue = objE_Solicitud.IdPersona;
                //cboTipoEgreso.EditValue = objE_Solicitud.IdTipoEgreso;
                //txtOC.Text = objE_Solicitud.NumOCompra;
                //txtObs.Text = objE_Solicitud.Obs;

                //speAbonoInicio.Value = Convert.ToInt32(objE_Solicitud.NroAbonoInicio);
                //speFin.Value = Convert.ToInt32(objE_Solicitud.NroAbonoFin);
                //txtAFacturar.Text = objE_Solicitud.RazonSocialFactura;

                //txtCuentaContable.Text = objE_Solicitud.CuentaContable.Trim();
                //txtTipoCambio.Text = (objE_Solicitud.TCambio).ToString();

                //btnGrabar.Enabled = false;
                //simpleButton1.Enabled = false;
                //simpleButton2.Enabled = false;
                //cboTipoEgreso.Enabled = false;
                //cboSolicitante.Enabled = false;
                //cboAsignar.Enabled = false;
                //cboMoneda.Enabled = false;
                //cboCuentaBancoProveedor.Enabled = false;
                //cboCentroCosto.ReadOnly = true;
                //cboTienda.ReadOnly = true;
                //txtDescProveedor.ReadOnly = true;
                //txtOC.ReadOnly = true;
                //txtSolicitudEgreso.ReadOnly = true;
                //txtCuenta.ReadOnly = true;
                //txtCCI.ReadOnly = true;
                //txtDescSolicitud.ReadOnly = true;
                //txtObs.ReadOnly = true;
                //txtAFacturar.ReadOnly = true;
                //txtNumeroDocumento.ReadOnly = true;
                //speFin.ReadOnly = true;
                //txtCuentaContable.ReadOnly = true;
                #endregion
            }

            //    CargaPrestamoBancoDetalle();
            //  CantidadDet = gvPrestamoBancoDetalle.RowCount;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (!ValidarIngreso())
                {
                    CuentaPorPagarBL objBL_SolicitudEgreso = new CuentaPorPagarBL();
                    CuentaPorPagarBE objCuentaPorPagar = new CuentaPorPagarBE();

                    objCuentaPorPagar.IdCuentaPagar = IdCuentaPagar;
                    objCuentaPorPagar.IdTipoOperacion = Convert.ToInt32(cboTipoOperacion.EditValue);
                    objCuentaPorPagar.IdBienServicio = Convert.ToInt32(cboTipoBien.EditValue);
                    objCuentaPorPagar.IdCentroCosto = Convert.ToInt32(cboCentroCosto.EditValue);
                    objCuentaPorPagar.IdAsignar = Convert.ToInt32(cboAsignar.EditValue);
                    objCuentaPorPagar.FechaDoc = Convert.ToDateTime(dteFechaEmision.EditValue);
                    objCuentaPorPagar.FechaVencimiento = Convert.ToDateTime(dteFechaVenc.EditValue);
                    objCuentaPorPagar.TCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objCuentaPorPagar.Importe = Convert.ToDecimal(txtImporte.EditValue);
                    objCuentaPorPagar.MontoAbono = Convert.ToDecimal(txtMontoAbono.EditValue);
                    objCuentaPorPagar.IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.EditValue);
                    objCuentaPorPagar.Serie = txtSerie.Text;
                    objCuentaPorPagar.Numero = txtNumFactura.Text;
                    objCuentaPorPagar.IdProveedor = IdProveedor;
                    objCuentaPorPagar.RucProveedor = txtNumeroDocumento.Text;
                    objCuentaPorPagar.NombreProveedor = txtDescProveedor.Text;
                    objCuentaPorPagar.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objCuentaPorPagar.IdSituacion = IdSituacion;
                    objCuentaPorPagar.Observacion = txtGlosa.Text;
                    objCuentaPorPagar.CuentaBN = txtCuentaBN.Text;
                    objCuentaPorPagar.CuentaProv = txtCuentaProv.Text;
                    objCuentaPorPagar.fechaBloque = Convert.ToDateTime(FechaBloque);
                    objCuentaPorPagar.IndiceBloque = IndiceBloque;
                    objCuentaPorPagar.NumeroBloque = NumeroGenerado;
                    objCuentaPorPagar.Estado = 1;

                    //objCuentaPorPagar.Importe = ImporteSoles;
                    objCuentaPorPagar.ImporteDolares = ImporteDolares;

                    GetSaldo();
                    objCuentaPorPagar.Saldo = Saldo;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_SolicitudEgreso.Inserta(objCuentaPorPagar);
                    }
                    else
                    {
                        //objBL_SolicitudEgreso.Actualiza(objSolicitudEgreso, lstListaSolicitudEgresoDetalle);
                        // EDGAR 250123: AGREGAR ACTUALIZAR CUENTA POR PAGAR
                        objBL_SolicitudEgreso.Actualiza(objCuentaPorPagar);
                    }

                    #region codigo anterior comentado
                    //objCuentaPorPagar.IdTipoOperacion = Convert.ToInt32(cboTipoOperacion.EditValue);
                    //objCuentaPorPagar.IdBienServicio = Convert.ToInt32(cboTipoBien.EditValue);
                    //objCuentaPorPagar.IdCentroCosto = Convert.ToInt32(cboCentroCosto.EditValue);
                    //objCuentaPorPagar.IdAsignar = Convert.ToInt32(cboAsignar.EditValue);
                    //objCuentaPorPagar.FechaDoc = Convert.ToDateTime(dteFechaEmision.EditValue);
                    //objCuentaPorPagar.FechaVencimiento = Convert.ToDateTime(dteFechaEmision.EditValue);
                    //objCuentaPorPagar.TCambio = Convert.ToDecimal(txtTipoCambio.Text);
                    //objCuentaPorPagar.IdTipoDocumento = Convert.ToInt32(cboTipoDocumento.EditValue);
                    //objCuentaPorPagar.IdProveedor = IdProveedor;
                    //objCuentaPorPagar.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);

                    //objCuentaPorPagar.IdBanco = Convert.ToInt32(cboCuentaBancoProveedor.EditValue);
                    //objCuentaPorPagar.IdPersona = Convert.ToInt32(cboSolicitante.EditValue);
                    //objCuentaPorPagar.NumOCompra = txtOC.Text.Trim();
                    //objCuentaPorPagar.NroAbonoInicio = Convert.ToInt32(speAbonoInicio.Value);
                    //objCuentaPorPagar.NroAbonoFin = Convert.ToInt32(speFin.Value);
                    //objCuentaPorPagar.IdTipoEgreso = Convert.ToInt32(cboTipoEgreso.EditValue);
                    //objCuentaPorPagar.IdTienda = Convert.ToInt32(cboTienda.EditValue);

                    //objSolicitudEgreso.IdCliente = IdCliente;
                    //objSolicitudEgreso.RazonSocialFactura = txtAFacturar.Text.Trim();

                    //objSolicitudEgreso.IdCentroCosto = Convert.ToInt32(cboCentroCosto.EditValue);
                    //objSolicitudEgreso.IdDetalleCentroCosto = Convert.ToInt32(cboAsignar.EditValue);
                    //objSolicitudEgreso.Obs = txtObs.Text.Trim();
                    //objSolicitudEgreso.Usuario = Usuario == "" ? Parametros.strUsuarioLogin : Usuario;
                    //objSolicitudEgreso.IdSituacion = 1;
                    //objSolicitudEgreso.CuentaContable = txtCuentaContable.Text.Trim();
                    //objSolicitudEgreso.TCambio = Convert.ToDecimal(txtTipoCambio.Text);

                    //Solicitud Egreso detalle
                    //Decimal vMontoTotal = 0;
                    //List<SolicitudEgresoDetalleBE> lstListaSolicitudEgresoDetalle = new List<SolicitudEgresoDetalleBE>();

                    //foreach (var item in mListaPrestamoBancoDetalleOrigen)
                    //{
                    //    SolicitudEgresoDetalleBE objE_SolicitudEgresoDetalle = new SolicitudEgresoDetalleBE();


                    //    objE_SolicitudEgresoDetalle.IdSolicitudEgresoDetalle = item.IdSolicitudEgresoDetalle;
                    //    objE_SolicitudEgresoDetalle.IdSolicitudEgreso = IdSolicitudEgreso;
                    //    objE_SolicitudEgresoDetalle.NumeroAbono = item.NumAbono;
                    //    objE_SolicitudEgresoDetalle.MontoAbono = item.Monto;

                    //    if (Convert.ToDateTime(item.FechaPagoSolicitada2) is Nullable || Convert.ToDateTime(item.FechaPagoSolicitada2) == Convert.ToDateTime("01/01/0001"))
                    //    {
                    //        XtraMessageBox.Show("Ingrese la(s) fecha(s) de solicitud de pago para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        objE_SolicitudEgresoDetalle.FechaPagoSolicitada = item.FechaPagoSolicitada2;
                    //    }

                    //    objE_SolicitudEgresoDetalle.FlagEstado = true;
                    //    objE_SolicitudEgresoDetalle.TipoOper = CantidadDet == 0 ? 1 : item.TipoOper;

                    //    vMontoTotal = vMontoTotal + item.Monto;

                    //    lstListaSolicitudEgresoDetalle.Add(objE_SolicitudEgresoDetalle);
                    //}

                    //objSolicitudEgreso.Total = vMontoTotal;


                    //if (pOperacion == Operacion.Nuevo)
                    //{
                    //    objBL_SolicitudEgreso.Inserta(objSolicitudEgreso, lstListaSolicitudEgresoDetalle);
                    //}
                    //else
                    //{
                    //    objBL_SolicitudEgreso.Actualiza(objSolicitudEgreso, lstListaSolicitudEgresoDetalle);
                    //}
                    #endregion

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

        private void cboCuentaBanco_EditValueChanged(object sender, EventArgs e)
        {
            #region codigo comentado
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
            #endregion
        }

        private void importartoolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cancelarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region codigo comentado
            //try
            //{
            //    int IdSituacion = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
            //    if (IdSituacion == Parametros.intSITPagoCancelado)
            //    {
            //        XtraMessageBox.Show("La cuota ya está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }

            //    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            //    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            //    frmAutoriza.ShowDialog();

            //    if (frmAutoriza.Edita)
            //    {
            //        frmEstablecerFecha frm = new frmEstablecerFecha();
            //        frm.Text = "Establecer Fecha de Pago";
            //        frm.StartPosition = FormStartPosition.CenterParent;
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
            //            PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

            //            int IdPrestamoBancoDetalle = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

            //            objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
            //            objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
            //            objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoCancelado;
            //            objE_PrestamoBancoDetalle.FechaPago = frm.Fecha;
            //            objE_PrestamoBancoDetalle.Usuario = frmAutoriza.Usuario;//Parametros.strUsuarioLogin;
            //            objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            //            objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

            //            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "DescSituacion", "CANCELADO");
            //            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoCancelado);
            //            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaPago", frm.Fecha);
            //            gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "UsuarioPago", frmAutoriza.Usuario);//Parametros.strUsuarioLogin);

            //            CalcularTotalSaldoPrestamo();
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            #endregion
        }

        private void gvPrestamoBancoDetalle_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            #region codigo comentado
            //try
            //{
            //    decimal decTotal = 0;
            //    decimal decTotalGeneral = 0;
            //    decimal decAmortizacion = 0;
            //    decimal decInteres = 0;
            //    decimal decEnvioInfo = 0;
            //    decimal decDesgravamen = 0;
            //    decimal decSeguro = 0;

            //    if (e.Column.FieldName == "Monto")
            //    {
            //        decAmortizacion = decimal.Parse(e.Value.ToString());
            //        decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Monto"])));
            //        decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
            //        decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
            //        decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
            //        decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));


            //        decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
            //        gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
            //    }
            //    //if (e.Column.FieldName == "Interes")
            //    //{
            //    //    decInteres = decimal.Parse(e.Value.ToString());
            //    //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
            //    //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
            //    //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
            //    //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
            //    //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

            //    //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
            //    //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
            //    //}
            //    //if (e.Column.FieldName == "EnvioInformacion")
            //    //{
            //    //    decEnvioInfo = decimal.Parse(e.Value.ToString());
            //    //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
            //    //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
            //    //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
            //    //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
            //    //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

            //    //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
            //    //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
            //    //}
            //    //if (e.Column.FieldName == "Desgravamen")
            //    //{
            //    //    decDesgravamen = decimal.Parse(e.Value.ToString());
            //    //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
            //    //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
            //    //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
            //    //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
            //    //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

            //    //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
            //    //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
            //    //}
            //    //if (e.Column.FieldName == "Seguro")
            //    //{
            //    //    decSeguro = decimal.Parse(e.Value.ToString());
            //    //    decAmortizacion = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Amortizacion"])));
            //    //    decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Interes"])));
            //    //    decEnvioInfo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["EnvioInformacion"])));
            //    //    decDesgravamen = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Desgravamen"])));
            //    //    decSeguro = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(e.RowHandle, (gvPrestamoBancoDetalle.Columns["Seguro"])));

            //    //    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
            //    //    gvPrestamoBancoDetalle.SetRowCellValue(e.RowHandle, gvPrestamoBancoDetalle.Columns["TotalPagar"], decTotal);
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
        }

        private void txtCuotas_KeyDown(object sender, KeyEventArgs e)
        {
            #region codigo comentado
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
            //                gvPrestamoBancoDetalle.AddNewRow();
            //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumeroCuota", i);
            //            }
            //        }
            //    }
            //}
            #endregion
        }

        private void habilitarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region codigo comentado
            //try
            //{
            //    int IdSituacion = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
            //    if (IdSituacion != Parametros.intSITPagoCancelado)
            //    {
            //        XtraMessageBox.Show("La cuota no está cancelada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }


            //    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            //    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            //    frmAutoriza.ShowDialog();

            //    if (frmAutoriza.Edita)
            //    {
            //        PrestamoBancoDetalleBE objE_PrestamoBancoDetalle = new PrestamoBancoDetalleBE();
            //        PrestamoBancoDetalleBL objBL_PrestamoBancoDetalle = new PrestamoBancoDetalleBL();

            //        int IdPrestamoBancoDetalle = int.Parse(gvPrestamoBancoDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

            //        objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
            //        objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
            //        objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoPendiente;
            //        objE_PrestamoBancoDetalle.FechaPago = null;
            //        objE_PrestamoBancoDetalle.Usuario = Parametros.strUsuarioLogin;
            //        objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

            //        objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

            //        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "DescSituacion", "PENDIENTE");
            //        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoPendiente);
            //        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaPago", null);
            //        gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "UsuarioPago", Parametros.strUsuarioLogin);

            //        CalcularTotalSaldoPrestamo();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text);
            //    //throw;
            //}
            #endregion
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            #region codigo comentado
            //if (pOperacion == Operacion.Modificar)
            //    {
            //     if (gvPrestamoBancoDetalle.RowCount > 0)
            //     {
            //         if (XtraMessageBox.Show("¿Esta seguro de generar nuevamente los abonos? Esto borra los abonos anteriores.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //         {
            //             SolicitudEgresoBE objSolicitudEgreso = new SolicitudEgresoBE();
            //             SolicitudEgresoBL objBL_SolicitudEgreso = new SolicitudEgresoBL();
            //             objSolicitudEgreso.IdSolicitudEgreso = IdSolicitudEgreso;
            //             objBL_SolicitudEgreso.Elimina(objSolicitudEgreso);

            //             gvPrestamoBancoDetalle.Focus();
            //             gvPrestamoBancoDetalle.SelectAll();
            //             gvPrestamoBancoDetalle.DeleteSelectedRows();

            //             int nCuotas = 0;
            //             nCuotas = Convert.ToInt32(speFin.Value);
            //             if (nCuotas > 0)
            //             {
            //                 for (int i = 1; i <= nCuotas; i++)
            //                 {
            //                     gvPrestamoBancoDetalle.AddNewRow();
            //                     gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumAbono", i);
            //                     gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", 1);
            //                 }
            //             }

            //         }
            //     }
            //     else
            //     {
            //         gvPrestamoBancoDetalle.Focus();
            //         gvPrestamoBancoDetalle.SelectAll();
            //         gvPrestamoBancoDetalle.DeleteSelectedRows();

            //         //if (pOperacion == Operacion.Nuevo)
            //         //{
            //             int nCuotas = 0;
            //             nCuotas = Convert.ToInt32(speFin.Value);
            //             if (nCuotas > 0)
            //             {
            //                 for (int i = 1; i <= nCuotas; i++)
            //                 {
            //                     gvPrestamoBancoDetalle.AddNewRow();
            //                     gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumAbono", i);
            //                 }
            //             }
            //         //}

            //     }
            //    }
            // else
            // {
            //     gvPrestamoBancoDetalle.Focus();
            //     gvPrestamoBancoDetalle.SelectAll();
            //     gvPrestamoBancoDetalle.DeleteSelectedRows();

            //     if (pOperacion == Operacion.Nuevo)
            //     {
            //         int nCuotas = 0;
            //         nCuotas = Convert.ToInt32(speFin.Value);
            //         if (nCuotas > 0)
            //         {
            //             for (int i = 1; i <= nCuotas; i++)
            //             {
            //                 gvPrestamoBancoDetalle.AddNewRow();
            //                 gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumAbono", i);
            //             }
            //         }
            //     }
            // }
            #endregion
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
            #region codigo comentado
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
            //        {
            //            ProveedorBE objE_Proveedor = null;
            //            objE_Proveedor = new ProveedorBL().SeleccionaNumero(txtNumeroDocumento.Text.Trim());
            //            if (objE_Proveedor != null)
            //            {
            //                IdProveedor = objE_Proveedor.IdProveedor;
            //                txtNumeroDocumento.Text = objE_Proveedor.NumeroDocumento.Trim();
            //                txtDescProveedor.Text = objE_Proveedor.DescProveedor.Trim();

            //                //Bloquear Ruc
            //                //   txtNumeroDocumento.Properties.ReadOnly = true;                    

            //                BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

            //                CuentaBancoBE objBE_CuentaBancoProveedor = null;
            //                objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
            //                if (objBE_CuentaBancoProveedor != null)
            //                {
            //                    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
            //                }

            //                //cboCuentaBancoProveedor.EditValue = Parametros.intSoles;
            //            }
            //            else
            //            {
            //                XtraMessageBox.Show("El proveedor no existe, debera registrarlo antes de continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            }
            //        }
            //        else
            //        {
            //            btnBuscar_Click(sender, e);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //   // XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
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
                    txtCuentaBN.Text = GetCuentaBN(IdProveedor);
                }

                #region codigo comentado
                //BSUtils.LoaderLook(cboCuentaBancoProveedor, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(IdProveedor, Convert.ToInt32(cboMoneda.EditValue)), "DescBanco", "IdCuentaBancoProveedor", true);

                //CuentaBancoBE objBE_CuentaBancoProveedor = null;
                //objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(cboCuentaBancoProveedor.EditValue));
                //if (objBE_CuentaBancoProveedor != null)
                //{
                //    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                //}
                #endregion
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCuentaBancoProveedor_EditValueChanged(object sender, EventArgs e)
        {
            #region codigo comentado
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
            #endregion
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (flag_cboMoneda)
                return;

            AplicarTC();

            #region codigo comentado
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
            #endregion
        }

        private void cboTipoEgreso_EditValueChanged(object sender, EventArgs e)
        {
            #region codigo comentado
            //if (pOperacion == Operacion.Nuevo)
            //{
            //    if (Convert.ToInt32(cboTipoEgreso.EditValue) == 518)
            //    {
            //        IdCliente = 236149;
            //        txtAFacturar.Text = "DECORATEX E.I.R.L.";
            //    }
            //    else if (Convert.ToInt32(cboTipoEgreso.EditValue) == 519)
            //    {
            //        IdCliente = 236149;
            //        txtAFacturar.Text = "DECORATEX E.I.R.L.";
            //    }
            //    else if (Convert.ToInt32(cboTipoEgreso.EditValue) == 520)
            //    {
            //        IdCliente = 0;
            //        txtAFacturar.Text = "";
            //    }
            //    else if (Convert.ToInt32(cboTipoEgreso.EditValue) == 521)
            //    {
            //        IdCliente = 0;
            //        txtAFacturar.Text = "";
            //    }
            //}
            #endregion
        }

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            #region codigo comentado
            //try
            //{
            //    frmBusClienteSolicitud frm = new frmBusClienteSolicitud();
            //    frm.pNumeroDescCliente = "";
            //    frm.pFlagMultiSelect = false;
            //    frm.ShowDialog();

            //    if (frm.pClienteBE != null)
            //    {
            //        IdCliente = frm.pClienteBE.IdCliente;
            //        txtAFacturar.Text = frm.pClienteBE.DescCliente;
            //    }
            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            #endregion
        }

        private void cboTipoOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboTipoBien.Focus();
            }
        }

        private void cboTipoBien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboCentroCosto.Focus();
            }
        }

        private void cboCentroCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboAsignar.Focus();
            }
        }

        private void cboAsignar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNumeroDocumento.Focus();
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboTipoDocumento.Focus();
            }
        }

        private void cboTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCuentaProv.Focus();
            }
        }
        private void txtCuentaProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCuentaBN.Focus();
            }
        }

        private void txtCuentaBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSerie.Focus();
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtNumFactura.Focus();
            }
        }

        private void txtNumFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dteFechaEmision.Focus();
            }
        }

        private void dteFechaEmision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dteFechaVenc.Focus();
            }
        }

        private void dteFechaVenc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cboMoneda.Focus();
            }
        }

        private void cboMoneda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtImporte.Focus();
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMontoAbono.Focus();
            }
        }

        private void txtMontoAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtGlosa.Focus();
            }
        }

        private void txtGlosa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGrabar.Focus();
            }
        }

        // EDGAR 240123: AGREGAR EVENTO AL MOMENTO DE SELECCIONAR UN TIPO DE BIEN O SERVICIO SE APLICA EL DESCUENTO PARA LA DETRACCION
        private void cboTipoBien_EditValueChanged(object sender, EventArgs e)
        {
            if (flag_cboTipoBien)
                return;

            AplicarTC();
            AplicarDetraccion();
        }

        // EDGAR 240123: AGREGAR EVENTO AL MOMENTO DE ESCRIBIR EL IMPORTE SE APLICA EL DESCUENTO PARA LA DETRACCION SI CUMPLE LA CONDICION
        private void txtImporte_EditValueChanged(object sender, EventArgs e)
        {
            if (flag_txtImporte)
                return;

            AplicarTC();
            AplicarDetraccion();
        }

        private void dteFechaEmision_EditValueChanged(object sender, EventArgs e)
        {
            if (flag_dteFechaEmision)
                return;

            DateTime FechaSinHoras = DateTime.Parse(dteFechaEmision.EditValue.ToString());
            String strFecha = FechaSinHoras.ToString("yyyy-MM-dd");

            DateTime FechaDoc = DateTime.Parse(strFecha);
            txtTipoCambio.EditValue = GetTCxFechaEmision(FechaDoc, 13);

            AplicarTC();
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

            flag_txtImporte = false; 
            flag_cboTipoBien = false; 
            flag_cboMoneda = false; 
            flag_dteFechaEmision = false;
        }
        #endregion "Eventos"

        #region "Metodos"
        #region "Validacion"
        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";

            if (cboTipoOperacion.Text.ToString() == "<NO DEFINIDO>")
            {
                strMensaje = strMensaje + "- Selecione el tipo de operacion.\n";
                flag = true;
            }

            if (cboTipoBien.Text.ToString() == "<NO DEFINIDO>")
            {
                strMensaje = strMensaje + "- Selecione el bien o servicio.\n";
                flag = true;
            }

            if (cboCentroCosto.Text.ToString() == "<NO DEFINIDO>")
            {
                strMensaje = strMensaje + "- Selecione el bien o servicio.\n";
                flag = true;
            }

            if (cboAsignar.Text.ToString() == "<NO DEFINIDO>")
            {
                strMensaje = strMensaje + "- Selecione el area del centro de costo.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el RUC del proveddor.\n";
                flag = true;
            }

            if (txtDescProveedor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Busque al proveedor.\n";
                flag = true;
            }

            if (cboTipoDocumento.Text.Trim().ToString() == "" || cboTipoDocumento.Text.Trim().ToString() == "<NO DEFINIDO>")
            {
                strMensaje = strMensaje + "- Selecione el tipo de documento.\n";
                flag = true;
            }

            if (txtCuentaBN.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- El proveedor no tiene cuenta en el Banco de la Nacion para efectuar la detraccion.\n";
                flag = true;
            }

            if (txtSerie.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la serie del documento.\n";
                flag = true;
            }

            if (txtNumFactura.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el numero del documento.\n";
                flag = true;
            }

            if (dteFechaEmision.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la fecha de emision.\n";
                flag = true;
            }

            if (dteFechaVenc.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la fecha de vencimiento.\n";
                flag = true;
            }

            if (cboMoneda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la moneda.\n";
                flag = true;
            }

            if (txtImporte.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el importe.\n";
                flag = true;
            }

            //if (txtMontoAbono.Text.Trim().ToString() == "" || txtMontoAbono.Text.ToString() == "0.00" || txtMontoAbono.Text.ToString() == "0")
            //{
            //    strMensaje = strMensaje + "- El documento debe tener detraccion.\n";
            //    flag = true;
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }
        #endregion "Validacion"

        #region Carga Prestamo Banco Detalle (Comentado)
        private void CargaPrestamoBancoDetalle()
        {
            //List<SolicitudEgresoDetalleBE> lstTmpPrestamoBancoDetalle = null;
            //lstTmpPrestamoBancoDetalle = new SolicitudEgresoDetalleBL().ListaTodosActivo(IdSolicitudEgreso);

            //foreach (SolicitudEgresoDetalleBE item in lstTmpPrestamoBancoDetalle)
            //{
            //    CSolicitudEgresoDetalle objE_SolicitudEgresoDetalle = new CSolicitudEgresoDetalle();

            //    objE_SolicitudEgresoDetalle.IdSolicitudEgreso = item.IdSolicitudEgreso;
            //    objE_SolicitudEgresoDetalle.IdSolicitudEgresoDetalle = item.IdSolicitudEgresoDetalle;
            //    objE_SolicitudEgresoDetalle.NumAbono = item.NumeroAbono;
            //    objE_SolicitudEgresoDetalle.FechaPagoSolicitada2 =Convert.ToDateTime( item.FechaPagoSolicitada);
            //    objE_SolicitudEgresoDetalle.Monto = item.MontoAbono;

            //    objE_SolicitudEgresoDetalle.TipoOper = Convert.ToInt32(Operacion.Consultar);

            //    mListaPrestamoBancoDetalleOrigen.Add(objE_SolicitudEgresoDetalle);
            //}

            //bsListado.DataSource = mListaPrestamoBancoDetalleOrigen;
            //gcPrestamoBancoDetalle.DataSource = bsListado;
            //gcPrestamoBancoDetalle.RefreshDataSource();

            //lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
        }
        #endregion

        #region Cargar Combo 
        private void CargarCombo()
        {
            mListaCuentaBanco = new CuentaBancoBL().Lista(0);
            if (mListaCuentaBanco.Count > 0)
            {
                #region codigo comentado
                //cboCuentaBanco.Properties.DataSource = mListaCuentaBanco;

                //cboCuentaBanco.EditValue = mListaCuentaBanco[0].IdCuentaBanco;
                //cboCuentaBanco.Properties.DisplayMember = "DescBanco";
                #endregion
            }
        }
        #endregion

        #region Importar Excel (comentado)
        //private void ImportarExcel(string filename)
        //{
        //    //if (pOperacion == Operacion.Nuevo)
        //    //{
        //    //    XtraMessageBox.Show("Debe grabar al menos un código, luego abrir e importar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    //    return;
        //    //}
        //    int TotalAgregado = 0;
        //    int TotalActualizado = 0;
        //    decimal decAmortizacion = 0;
        //    decimal decTotalInteres = 0;
        //    decimal decInteres = 0;
        //    int intCuotas = 0;
        //    DateTime FechaVen= DateTime.Now;
        //    string sNumeroPrestamo = "";


        //    if (filename.Trim() == "")
        //        return;

        //    Excel._Application xlApp;
        //    Excel._Workbook xlLibro;
        //    Excel._Worksheet xlHoja;
        //    Excel.Sheets xlHojas;
        //    xlApp = new Excel.Application();
        //    xlLibro = xlApp.Workbooks.Open(filename, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
        //    xlHojas = xlLibro.Sheets;
        //    xlHoja = (Excel._Worksheet)xlHojas[1];

        //    int Row = 2;
        //    int TotRow = 2;

        //    try
        //    {
        //        //Contador de Registros
        //        while ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
        //        {
        //            if ((string)xlHoja.get_Range("A" + TotRow, Missing.Value).Text.ToString().ToUpper().Trim() != "")
        //                TotRow++;
        //        }
        //        TotRow = TotRow - Row + 1;
        //        //prgFactura.Properties.Step = 1;
        //        //prgFactura.Properties.Maximum = TotRow;
        //        //prgFactura.Properties.Minimum = 0;


        //        //Recorremos los códigos de PromocionTemporal
        //        while ((string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().ToUpper().Trim() != "")
        //        {
        //            string NumeroCuota = (string)xlHoja.get_Range("A" + Row, Missing.Value).Text.ToString().Trim();
        //            DateTime FechaVencimiento = Convert.ToDateTime((string)xlHoja.get_Range("B" + Row, Missing.Value).Text.ToString().Trim());
        //            string SaldoPendiente = (string)xlHoja.get_Range("C" + Row, Missing.Value).Text.ToString().Trim();
        //            string Amortizacion = (string)xlHoja.get_Range("D" + Row, Missing.Value).Text.ToString().Trim();
        //            string Interes = (string)xlHoja.get_Range("E" + Row, Missing.Value).Text.ToString().Trim();
        //            string EnvioInformacion = (string)xlHoja.get_Range("F" + Row, Missing.Value).Text.ToString().Trim();
        //            string Desgravamen = (string)xlHoja.get_Range("G" + Row, Missing.Value).Text.ToString().Trim();
        //            string Seguro = (string)xlHoja.get_Range("H" + Row, Missing.Value).Text.ToString().Trim();
        //            string TotalPagar = (string)xlHoja.get_Range("I" + Row, Missing.Value).Text.ToString().Trim();
        //            string Moneda = (string)xlHoja.get_Range("J" + Row, Missing.Value).Text.ToString().Trim();
        //            string Cuotas = (string)xlHoja.get_Range("K" + Row, Missing.Value).Text.ToString().Trim();
        //            string NumeroPrestamo = (string)xlHoja.get_Range("L" + Row, Missing.Value).Text.ToString().Trim();


        //            if (pOperacion == Operacion.Nuevo)
        //            {
        //                gvPrestamoBancoDetalle.AddNewRow();
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdPrestamoBanco", IdPrestamoBanco);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "IdPrestamoBancoDetalle", 0);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "NumeroCuota", NumeroCuota);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FechaVencimiento", FechaVencimiento);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "SaldoPendiente", SaldoPendiente);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Amortizacion", Amortizacion);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Interes", Interes);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Desgravamen", Desgravamen);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "Seguro", Seguro);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TotalPagar", TotalPagar);
        //                gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "FlagEstado", true);
        //                if (pOperacion == Operacion.Modificar)
        //                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
        //                else
        //                    gvPrestamoBancoDetalle.SetRowCellValue(gvPrestamoBancoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

        //                TotalAgregado = TotalAgregado + 1;
        //            }

        //            decTotalInteres = decTotalInteres + Convert.ToDecimal(Interes);
        //            decInteres = decInteres + Convert.ToDecimal(Interes);
        //            intCuotas = Convert.ToInt32(Cuotas);
        //            FechaVen = FechaVencimiento;
        //            sNumeroPrestamo = NumeroPrestamo;
        //            decAmortizacion = decAmortizacion + Convert.ToDecimal(Amortizacion);
        //            //prgFactura.PerformStep();
        //            //prgFactura.Update();

        //            Row++;
        //        }

        //        //txtSaldoPrestamo.EditValue = decAmortizacion;
        //        //txtSaldoInteres.EditValue = decTotalInteres;
        //        //txtInteres.EditValue = decInteres;
        //        //txtCuotas.EditValue = intCuotas;
        //        //deFechaVencimiento.EditValue = FechaVen;
        //        //txtNumeroPrestamo.Text = sNumeroPrestamo;
        //        lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";



        //        XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


        //        xlLibro.Close(false, Missing.Value, Missing.Value);
        //        xlApp.Quit();
        //        if (pOperacion == Operacion.Modificar)
        //        {
        //            this.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor = Cursors.Default;
        //        xlLibro.Close(false, Missing.Value, Missing.Value);
        //        xlApp.Quit();
        //        XtraMessageBox.Show(ex.Message + "Linea : " + Row.ToString() + " \n Por favor cierre la ventana, vefique el formato del archivo excel.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        #endregion

        #region Caluclar Total Saldo Prestamo (comentado)
        private void CalcularTotalSaldoPrestamo()
        {
            //try
            //{
            //    decimal decSaldo = 0;
            //    decimal decInteres = 0;
            //    decimal decTotalInteres = 0;
            //    decimal decMayorSaldo = 0;
            //    int intSituacion = 0;

            //    for (int i = 0; i < gvPrestamoBancoDetalle.RowCount; i++)
            //    {
            //        intSituacion = Convert.ToInt32(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["IdSituacion"])));

            //        decSaldo = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["SaldoPendiente"])));
            //        decInteres = Convert.ToDecimal(gvPrestamoBancoDetalle.GetRowCellValue(i, (gvPrestamoBancoDetalle.Columns["Interes"])));

            //        if (intSituacion != Parametros.intSITPagoCancelado)
            //        {
            //            decTotalInteres = decTotalInteres + decInteres;

            //            if(decSaldo > decMayorSaldo)
            //            {
            //                decMayorSaldo = decSaldo;
            //            }
            //        }
            //    }
            //    //txtSaldoPrestamo.EditValue = decMayorSaldo;
            //    //txtSaldoInteres.EditValue = decTotalInteres;
            //    //lblTotalRegistros.Text = gvPrestamoBancoDetalle.RowCount.ToString() + " Registros";
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion

        #region Aplicar Detraccion
        // EDGAR 240123: AGREGAR METODO PARA APLICAR DETRACCION
        private void AplicarDetraccion()
        {
            Decimal importe = Convert.ToDecimal(ImporteSoles.ToString() == "" ? 0 : ImporteSoles);
            Int32 TipoBien = Convert.ToInt32(cboTipoBien.EditValue);
            // DateTime fecha = dteFechaEmision.DateTime;

            if (importe > 700)
            {
                // EDGAR 250123: AGREGAR PROGRAMACION PARA OBTENER EL DESCUENTO DESDE LA BD
                CuentaPorPagarBL CuentaPorPagar = new CuentaPorPagarBL();

                List<TablaElementoDetraccionBE> Detraccionlist = new List<TablaElementoDetraccionBE>();
                Detraccionlist = CuentaPorPagar.ListaTodosActivoDetracciones();

                foreach (var d in Detraccionlist)
                {
                    if (TipoBien == d.IdTablaElemento)
                    {
                        txtMontoAbono.EditValue = GetReound(importe * d.Valor / 100);
                        break;
                    }
                }

                #region Switch provision para la detraccion (comentado)
                // EDGAR 240123: SWITCH PROVISIONAL, DEBE JALAR EL DESCUENTO DE LA BASE DE DATOS
                //switch (Convert.ToInt32(cboTipoBien.EditValue))
                //{
                //    case 577:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    case 578:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    case 579:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    case 580:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 581:
                //        txtMontoAbono.EditValue = importe * 15 / 100;
                //        break;
                //    case 582:
                //        txtMontoAbono.EditValue = importe * 12 / 100;
                //        break;
                //    case 583:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    case 584:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    case 585:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 586:
                //        txtMontoAbono.EditValue = importe * 12 / 100;
                //        break;
                //    case 587:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 588:
                //        txtMontoAbono.EditValue = importe * 12 / 100;
                //        break;
                //    case 589:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 590:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 591:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 592:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    case 593:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    case 594:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 595:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 596:
                //        txtMontoAbono.EditValue = importe * Convert.ToDecimal(1.5) / 100;
                //        break;
                //    case 597:
                //        txtMontoAbono.EditValue = importe * Convert.ToDecimal(1.5) / 100;
                //        break;
                //    case 598:
                //        txtMontoAbono.EditValue = importe * 12 / 100;
                //        break;
                //    case 599:
                //        txtMontoAbono.EditValue = importe * 10 / 100;
                //        break;
                //    case 600:
                //        txtMontoAbono.EditValue = importe * 4 / 100;
                //        break;
                //    default:
                //        txtMontoAbono.EditValue = 0;
                //        break;
                //}
                #endregion
            }
            else
            {
                txtMontoAbono.EditValue = 0;
            }
        }
        #endregion

        private String GetCuentaBN(Int32 IdProveedor)
        {
            CuentaPorPagarBL CuentaPorPagar = new CuentaPorPagarBL();
            return CuentaPorPagar.GetCuentaBN(IdProveedor);
        }

        public Decimal GetReound(Decimal MontoAbono)
        {
            return Math.Round(MontoAbono);
        }

        public Decimal GetTCxFechaEmision(DateTime FechaDoc, Int32 IdEmpresa)
        {
            CuentaPorPagarBL CuentaPorPagar = new CuentaPorPagarBL();
            return CuentaPorPagar.GetTCxFechaEmision(FechaDoc, IdEmpresa);
        }

        public void AplicarTC()
        {
            Decimal ValorImporte = Convert.ToDecimal(txtImporte.EditValue == null || txtImporte.EditValue.ToString() == "" ? "0" : txtImporte.EditValue.ToString());
            Decimal ValorTC = Convert.ToDecimal(txtTipoCambio.EditValue == null || txtTipoCambio.EditValue.ToString() == "" ? "1" : txtTipoCambio.EditValue.ToString());
            String Moneda = cboMoneda.EditValue == null ? "0" : cboMoneda.EditValue.ToString();

            if (Moneda == "5")
            { // soles
                try
                {
                    txtImporte.Text = ImporteSoles.ToString();
                }
                finally
                {
                    ImporteSoles = ValorImporte;
                    ImporteDolares = ValorImporte / ValorTC;
                    txtImporte.Text = ImporteSoles.ToString();
                }
            }
            else if (Moneda == "6")
            { // dolares
                try
                {
                    txtImporte.Text = ImporteDolares.ToString();
                }
                finally
                {
                    ImporteDolares = ValorImporte;
                    ImporteSoles = ValorImporte * ValorTC;
                    txtImporte.Text = ImporteDolares.ToString();
                }
            }
            else
            {
                ImporteDolares = 0; ImporteSoles = 0; txtImporte.Text = 0.ToString();
            }
        }

        public void AplicarTCModificar()
        {
            #region codigo comentado
            //String Moneda = cboMoneda.EditValue == null ? "0" : cboMoneda.EditValue.ToString();

            //if (Moneda == "5")
            //{ // soles
            //    txtImporte.Text = ImporteSoles.ToString();
            //}
            //else if (Moneda == "6")
            //{ // dolares
            //    txtImporte.Text = ImporteDolares.ToString();
            //}
            //else
            //{
            //    txtImporte.Text = 0.ToString();
            //}
            #endregion
        }

        public void GetSaldo()
        {
            Moneda = Convert.ToInt32(cboMoneda.EditValue);
            Importe = Convert.ToDecimal(txtImporte.EditValue);
            MontoAbono = Convert.ToDecimal(txtMontoAbono.EditValue);
            TCambio = Convert.ToDecimal(txtTipoCambio.EditValue);

            if (Moneda == Parametros.intSoles)
                Saldo = Importe - MontoAbono;
            else if (Moneda == Parametros.intDolares)
                Saldo = Importe - (MontoAbono / TCambio);
        }
        #endregion "Metodos"

        #region "Clases"
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
        #endregion "Clases"
    }
}