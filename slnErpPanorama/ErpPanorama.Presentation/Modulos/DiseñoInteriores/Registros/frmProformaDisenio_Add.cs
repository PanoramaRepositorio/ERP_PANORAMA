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
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Funciones;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmProformaDisenio_Add : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PrestamoBancoBE> lstPrestamoBanco;
        public List<ProformaDisenioDetalle> mListaProformaDisenioDetalleOrigen = new List<ProformaDisenioDetalle>();
        private List<ProformaDisenioDetalleBE> lst_Dis_ContratoFabricacionDetalleMsg = new List<ProformaDisenioDetalleBE>();

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
        public int IdProformaDisenio = 0;
        public int IdProformaDisenioDetalle = 0;
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

        int _IdTipoCliente = 0;

        public int IdTipoCliente
        {
            get { return _IdTipoCliente; }
            set { _IdTipoCliente = value; }
        }
     
       private int NumCar = 0;
        #endregion

        #region "Eventos"
        public frmProformaDisenio_Add()
        {
            InitializeComponent();
        }

        private void frmProformaDisenio_Add_Load(object sender, EventArgs e)
        {
            //BSUtils.LoaderLook(cboCuentaBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            cboFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = 0;
            //cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboDisenador, new PersonaBL().SeleccionaDisenador(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboDisenador.EditValue = Parametros.intPersonaId;


            //BSUtils.LoaderLook(cboCentroCosto, new TablaBL().ListaTodosActivoCentroCosto(Parametros.intEmpresaId), "DescTabla", "IdTabla", true);
            //cboCentroCosto.EditValue = 86;
            //BSUtils.LoaderLook(cboAsignar, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId,Convert.ToInt32(cboCentroCosto.EditValue)), "DescTablaElemento", "IdTablaElemento", true);

            //BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosTiendasActivo2(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            //cboAsignar.EditValue = 15;
            //BSUtils.LoaderLook(cboTipoPrestamo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoPrestamo), "DescTablaElemento", "IdTablaElemento", true);
            //BSUtils.LoaderLook(cboSolicitante, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", false);
            //cboSolicitante.EditValue = Parametros.intPersonaId;
            //CargarCombo
            if (pOperacion == Operacion.Nuevo)
            {
                //CargarCombo();
                this.Text = "Nueva Proforma de Diseño";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Solicitud - Editar";

                ProformaDisenioBE objE_Solicitud = null;
                objE_Solicitud = new ProformaDisenioBL().Buscar_SolicitudEgreso(IdProformaDisenio);

                Usuario = objE_Solicitud.UsuarioModificacion;

                //txtSolicitudEgreso.Text = objE_Solicitud.NumSolicitudEgreso;
                //cboFecha.EditValue = objE_Solicitud.FechaSolicitudEgreso;
                cboMoneda.EditValue = objE_Solicitud.IdMoneda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;

                txtNumeroDocumento.Text = objE_Solicitud.NumeroDocumento;
                //txtDescCliente.Text = objE_Solicitud.DescProveedor;
                //IdProveedor = objE_Solicitud.IdProveedor;

                //cboTienda.EditValue = objE_Solicitud.IdTienda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;
                //////
                //BSUtils.LoaderLook(cboDisenador, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(objE_Solicitud.IdProveedor, Convert.ToInt32(objE_Solicitud.IdMoneda)), "DescBanco", "IdCuentaBancoProveedor", true);

                //CuentaBancoBE objBE_CuentaBancoProveedor = null;
                //objBE_CuentaBancoProveedor = new CuentaBancoBL().Selecciona_CuentaBancoProveedor(Convert.ToInt32(objE_Solicitud.IdBanco));
                //if (objBE_CuentaBancoProveedor != null)
                //{
                //    txtCuenta.EditValue = objBE_CuentaBancoProveedor.NumeroCuenta;
                //}
                IdCliente = objE_Solicitud.IdCliente;

                //cboDisenador.EditValue = objE_Solicitud.IdBanco;
                //txtCorreo.Text = objE_Solicitud.Cuenta;
                //txtCCI.Text = objE_Solicitud.CCI;
                //txtDescSolicitud.Text = objE_Solicitud.DescSolicitudEgreso;
                //cboSolicitante.EditValue = objE_Solicitud.IdPersona;
                //cboTipoEgreso.EditValue = objE_Solicitud.IdTipoEgreso;
                //txtOC.Text = objE_Solicitud.NumOCompra;
                txtObs.Text = objE_Solicitud.Obs;

                //    speAbonoInicio.Value = Convert.ToInt32(objE_Solicitud.NroAbonoInicio);
                //    speFin.Value = Convert.ToInt32(objE_Solicitud.NroAbonoFin);
                //    txtAFacturar.Text = objE_Solicitud.RazonSocialFactura;
                //    txtCuentaContable.Text = objE_Solicitud.CuentaContable.Trim();
            }
            else if (pOperacion == Operacion.Consultar)
            {
                this.Text = "Solicitud - Consulta";

                SolicitudEgresoBE objE_Solicitud = null;
                objE_Solicitud = new SolicitudEgresoBL().Buscar_SolicitudEgreso(IdProformaDisenio);

                txtSolicitudEgreso.Text = objE_Solicitud.NumSolicitudEgreso;
                cboFecha.EditValue = objE_Solicitud.FechaSolicitudEgreso;
                cboMoneda.EditValue = objE_Solicitud.IdMoneda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;

                txtNumeroDocumento.Text = objE_Solicitud.NumeroDocumento;
                txtDescCliente.Text = objE_Solicitud.DescProveedor;
                IdProveedor = objE_Solicitud.IdProveedor;

                //cboTienda.EditValue = objE_Solicitud.IdTienda;
                //cboCentroCosto.EditValue = objE_Solicitud.IdCentroCosto;
                //cboAsignar.EditValue = objE_Solicitud.IdDetalleCentroCosto;
                //////
                BSUtils.LoaderLook(cboDisenador, new CuentaBancoBL().ListaTodosCuentaBancosProveedor(objE_Solicitud.IdProveedor, Convert.ToInt32(objE_Solicitud.IdMoneda)), "DescBanco", "IdCuentaBancoProveedor", true);

                IdCliente = objE_Solicitud.IdCliente;

                cboDisenador.EditValue = objE_Solicitud.IdBanco;
                txtCorreo.Text = objE_Solicitud.Cuenta;
                //txtCCI.Text = objE_Solicitud.CCI;
                txtDireccion.Text = objE_Solicitud.DescSolicitudEgreso;
                //cboSolicitante.EditValue = objE_Solicitud.IdPersona;
                //cboTipoEgreso.EditValue = objE_Solicitud.IdTipoEgreso;
                //txtOC.Text = objE_Solicitud.NumOCompra;
                txtObs.Text = objE_Solicitud.Obs;

                //speAbonoInicio.Value = Convert.ToInt32(objE_Solicitud.NroAbonoInicio);
                //speFin.Value = Convert.ToInt32(objE_Solicitud.NroAbonoFin);
                //txtAFacturar.Text = objE_Solicitud.RazonSocialFactura;

                //txtCuentaContable.Text = objE_Solicitud.CuentaContable.Trim();

                btnGrabar.Enabled = false;
                //simpleButton1.Enabled = false;
                //simpleButton2.Enabled = false;
                //cboTipoEgreso.Enabled = false;
                //cboSolicitante.Enabled = false;
                //cboAsignar.Enabled = false;
                cboMoneda.Enabled = false;
                cboDisenador.Enabled = false;
                //cboCentroCosto.ReadOnly = true;
                //cboTienda.ReadOnly = true;
                txtDescCliente.ReadOnly = true;
                //txtOC.ReadOnly = true;
                txtSolicitudEgreso.ReadOnly = true;
                txtCorreo.ReadOnly = true;
                //txtCCI.ReadOnly = true;
                txtDireccion.ReadOnly = true;
                txtObs.ReadOnly = true;
                //txtAFacturar.ReadOnly = true;
                txtNumeroDocumento.ReadOnly = true;
                //speFin.ReadOnly = true;
                //txtCuentaContable.ReadOnly = true;
            }

            CargaPrestamoBancoDetalle();
            CantidadDet = gvProformaDisenioDetalle.RowCount;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                int TipProforma = 0;

                if (rb1.Checked==true)  //Decoración
                { TipProforma = 1;  }
                else if (rb2.Checked == true) //Fabricación
                { TipProforma = 2; }
                else if (rb3.Checked == true)  // Decoración y Fabricacion
                { TipProforma = 3; }
                else if (rb4.Checked == true) // Servicio de asesoria y diseño
                { TipProforma = 4; }

                if (!ValidarIngreso())
                {
                    ProformaDisenioBL objBL_SolicitudEgreso = new ProformaDisenioBL();
                    ProformaDisenioBE objProformaDisenio = new ProformaDisenioBE();

                    // Cabecera de Proforma de Diseño
                    objProformaDisenio.IdProformaDisenio = IdProformaDisenio;
                    objProformaDisenio.FechaProformaDisenio = Convert.ToDateTime(cboFecha.EditValue);
                    objProformaDisenio.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objProformaDisenio.IdCliente = IdCliente;
                    objProformaDisenio.DireccionCliente = txtDireccion.Text.Trim();
                    objProformaDisenio.CorreoEnvio = txtCorreo.Text.Trim();
                    objProformaDisenio.Referencia = txtReferencia.Text.Trim();
                    objProformaDisenio.IdAsesor = Convert.ToInt32(cboDisenador.EditValue);
                    objProformaDisenio.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objProformaDisenio.Obs = txtObs.Text.Trim();
                    objProformaDisenio.UsuarioCreacion = Parametros.strUsuarioLogin;
                    objProformaDisenio.UsuarioModificacion = Parametros.strUsuarioLogin;   //Usuario==""? Parametros.strUsuarioLogin : Usuario ;
                    objProformaDisenio.IdSituacion = 1;
                    objProformaDisenio.IdTipoProformaDisenio = TipProforma;

                    //Detalle de Proforma Diseño
                    Decimal vMontoTotal = 0;
                    List<ProformaDisenioDetalleBE> lstListaProformaDisenioDetalle = new List<ProformaDisenioDetalleBE>();

                    foreach (var item in mListaProformaDisenioDetalleOrigen)
                    {
                        ProformaDisenioDetalleBE objE_ProformaDisenioDetalle = new ProformaDisenioDetalleBE();

                        objE_ProformaDisenioDetalle.IdProformaDisenio = item.IdProformaDisenio;
                        objE_ProformaDisenioDetalle.IdProformaDisenioDetalle = IdProformaDisenioDetalle;
                        objE_ProformaDisenioDetalle.IdSituacionProducto = item.IdSituacionProducto;
                        objE_ProformaDisenioDetalle.IdProducto = item.IdProducto;
                        objE_ProformaDisenioDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_ProformaDisenioDetalle.NombreProducto = item.NombreProducto;
                        objE_ProformaDisenioDetalle.Abreviatura = item.Abreviatura;
                        objE_ProformaDisenioDetalle.Material = item.Material;
                        objE_ProformaDisenioDetalle.Modelo = item.Modelo;
                        objE_ProformaDisenioDetalle.Medida = item.Medida;
                        objE_ProformaDisenioDetalle.Imagen = item.Imagen;
                        objE_ProformaDisenioDetalle.Cantidad = item.Cantidad;
                        objE_ProformaDisenioDetalle.PrecioUnitario = item.Precio;
                        objE_ProformaDisenioDetalle.ValorVenta = item.ValorVenta;
                        objE_ProformaDisenioDetalle.Observacion = item.Observacion;
                        //if (Convert.ToDateTime(item.FechaPagoSolicitada2) is Nullable || Convert.ToDateTime(item.FechaPagoSolicitada2) == Convert.ToDateTime("01/01/0001"))
                        //{
                        //    XtraMessageBox.Show("Ingrese la(s) fecha(s) de solicitud de pago para continuar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //    return;
                        //}
                        //else
                        //{
                        //    objE_ProformaDisenioDetalle.FechaPagoSolicitada = item.FechaPagoSolicitada2;
                        //}
                        //objE_ProformaDisenioDetalle.TipoOper = CantidadDet == 0 ? 1 : item.TipoOper;
                        vMontoTotal = vMontoTotal + item.ValorVenta;

                        lstListaProformaDisenioDetalle.Add(objE_ProformaDisenioDetalle);
                    }
                    objProformaDisenio.Total = vMontoTotal;

                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_SolicitudEgreso.Inserta(objProformaDisenio, lstListaProformaDisenioDetalle);
                    }
                    else
                    {
                        objBL_SolicitudEgreso.Actualiza(objProformaDisenio, lstListaProformaDisenioDetalle);
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
                int IdSituacion = int.Parse(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
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

                        int IdPrestamoBancoDetalle = int.Parse(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                        objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                        objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                        objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoCancelado;
                        objE_PrestamoBancoDetalle.FechaPago = frm.Fecha;
                        objE_PrestamoBancoDetalle.Usuario = frmAutoriza.Usuario;//Parametros.strUsuarioLogin;
                        objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "DescSituacion", "CANCELADO");
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoCancelado);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "FechaPago", frm.Fecha);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "UsuarioPago", frmAutoriza.Usuario);//Parametros.strUsuarioLogin);

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
                    decAmortizacion = Convert.ToDecimal(gvProformaDisenioDetalle.GetRowCellValue(e.RowHandle, (gvProformaDisenioDetalle.Columns["Monto"])));
                    decInteres = Convert.ToDecimal(gvProformaDisenioDetalle.GetRowCellValue(e.RowHandle, (gvProformaDisenioDetalle.Columns["Interes"])));
                    decEnvioInfo = Convert.ToDecimal(gvProformaDisenioDetalle.GetRowCellValue(e.RowHandle, (gvProformaDisenioDetalle.Columns["EnvioInformacion"])));
                    decDesgravamen = Convert.ToDecimal(gvProformaDisenioDetalle.GetRowCellValue(e.RowHandle, (gvProformaDisenioDetalle.Columns["Desgravamen"])));
                    decSeguro = Convert.ToDecimal(gvProformaDisenioDetalle.GetRowCellValue(e.RowHandle, (gvProformaDisenioDetalle.Columns["Seguro"])));


                    decTotal = decAmortizacion + decInteres + decEnvioInfo + decDesgravamen + decSeguro;
                    gvProformaDisenioDetalle.SetRowCellValue(e.RowHandle, gvProformaDisenioDetalle.Columns["TotalPagar"], decTotal);
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
            //                gvProformaDisenioDetalle.AddNewRow();
            //                gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "NumeroCuota", i);
            //            }
            //        }
            //    }
            //}
        }

        private void habilitarcuotatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdSituacion = int.Parse(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdSituacion").ToString());
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

                    int IdPrestamoBancoDetalle = int.Parse(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdPrestamoBancoDetalle").ToString());

                    objE_PrestamoBancoDetalle.IdPrestamoBanco = IdPrestamoBanco;
                    objE_PrestamoBancoDetalle.IdPrestamoBancoDetalle = IdPrestamoBancoDetalle;
                    objE_PrestamoBancoDetalle.IdSituacion = Parametros.intSITPagoPendiente;
                    objE_PrestamoBancoDetalle.FechaPago = null;
                    objE_PrestamoBancoDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_PrestamoBancoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    objBL_PrestamoBancoDetalle.ActualizaSituacion(objE_PrestamoBancoDetalle);

                    gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "DescSituacion", "PENDIENTE");
                    gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdSituacion", Parametros.intSITPagoPendiente);
                    gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "FechaPago", null);
                    gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "UsuarioPago", Parametros.strUsuarioLogin);

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

        private void CalculaTotales()
        {
            try
            {
                decimal TotalCotizado = 0;

                decimal deTotal = 0;
                decimal CantidadTotal = 0;
                decimal CantidadAprobado = 0;
                decimal deTotalAprobado = 0;
                decimal TotalRegistros = 0;

                if (mListaProformaDisenioDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaProformaDisenioDetalleOrigen)
                    {
                        CantidadTotal = CantidadTotal + item.Cantidad;
                        deTotal = deTotal + item.ValorVenta;

                        if (item.FlagAprobado)
                        {
                            if (!item.FlagObsequio)
                            {
                                CantidadAprobado = CantidadAprobado + item.Cantidad;
                                deTotalAprobado = deTotalAprobado + item.ValorVenta;
                            }
                        }
                        if (item.ValorVenta > 0)
                        {
                            TotalCotizado = TotalCotizado + 1;
                        }

                    }
                    txtTotalCantidad.EditValue = Math.Round(CantidadTotal, 2);
                    txtTotalVenta.EditValue = Math.Round(deTotal, 2);

                    //txtCantidadAprobada.EditValue = Math.Round(CantidadAprobado, 2);
                    //txtTotalAprobado.EditValue = Math.Round(deTotalAprobado, 2);

                    //Porcentaje de Avance
                    TotalRegistros = mListaProformaDisenioDetalleOrigen.Count;
                    //lblCotizacion.Text = Convert.ToString(Math.Round((TotalCotizado / TotalRegistros) * 100, 0));

                }
                else
                {
                    //lblCotizacion.Text = "0";
                    txtTotalCantidad.EditValue = 0;
                    txtTotalVenta.EditValue = 0;
                    //txtCantidadAprobada.EditValue = 0;
                    //txtTotalAprobado.EditValue = 0;
                }

                lblTotalRegistros.Text = mListaProformaDisenioDetalleOrigen.Count.ToString() + " Registros encontrados";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidarIngreso()
        {
            bool flag = false;

            string strMensaje = "No se pudo registrar:\n";

            //if (IdCuentaBanco == 0)
            //{
            //    strMensaje = strMensaje + "- Selecione el banco.\n";
            //    flag = true;
            //}

            if (txtDescCliente.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el cliente de la proforma de diseño.\n";
                flag = true;
            }

            if (txtDireccion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la dirección de la proforma de diseño.\n";
                flag = true;
            }


            //if (txtAFacturar.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese la razón social a facturar.\n";
            //    flag = true;
            //}
            

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

            //if (cboTipoEgreso.EditValue.ToString() == "0")
            //{
            //    strMensaje = strMensaje + "- Selecione el tipo de egreso.\n";
            //    flag = true;
            //}

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
            List<ProformaDisenioDetalleBE> lstTmpProformaDisenioDetalle = null;
            lstTmpProformaDisenioDetalle = new ProformaDisenioDetalleBL().ListaTodosActivo(IdProformaDisenio);

            foreach (ProformaDisenioDetalleBE item in lstTmpProformaDisenioDetalle)
            {
                ProformaDisenioDetalle objE_ProformaDisenioDetalle = new ProformaDisenioDetalle();

                objE_ProformaDisenioDetalle.IdProformaDisenio = item.IdProformaDisenio;
                objE_ProformaDisenioDetalle.IdProformaDisenioDetalle = item.IdProformaDisenioDetalle;
                objE_ProformaDisenioDetalle.IdSituacionProducto = item.IdSituacionProducto;
                objE_ProformaDisenioDetalle.IdProducto = item.IdProducto;
                objE_ProformaDisenioDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_ProformaDisenioDetalle.NombreProducto = item.NombreProducto;
                objE_ProformaDisenioDetalle.Abreviatura = item.NombreProducto;

                objE_ProformaDisenioDetalle.IdUnidadMedida = item.IdUnidadMedida;
                objE_ProformaDisenioDetalle.Modelo = item.NombreProducto;
                objE_ProformaDisenioDetalle.Medida = item.NombreProducto;
                objE_ProformaDisenioDetalle.Material = item.NombreProducto;

                objE_ProformaDisenioDetalle.Cantidad = item.Cantidad;
                objE_ProformaDisenioDetalle.Precio = item.Precio;
                objE_ProformaDisenioDetalle.ValorVenta = item.ValorVenta;

                objE_ProformaDisenioDetalle.Observacion = item.Observacion;
                objE_ProformaDisenioDetalle.Imagen = item.Imagen;

                objE_ProformaDisenioDetalle.TipoOper = Convert.ToInt32(Operacion.Consultar);

                mListaProformaDisenioDetalleOrigen.Add(objE_ProformaDisenioDetalle);
            }

            bsListado.DataSource = mListaProformaDisenioDetalleOrigen;
            gcProformaDisenioDetalle.DataSource = bsListado;
            gcProformaDisenioDetalle.RefreshDataSource();

            lblTotalRegistros.Text = gvProformaDisenioDetalle.RowCount.ToString() + " Registros";
        }

        private void CargarCombo()
        {
            //mListaCuentaBanco = new CuentaBancoBL().Lista(0);
            //if (mListaCuentaBanco.Count > 0)
            //{
            //    //cboCuentaBanco.Properties.DataSource = mListaCuentaBanco;

            //    //cboCuentaBanco.EditValue = mListaCuentaBanco[0].IdCuentaBanco;
            //    //cboCuentaBanco.Properties.DisplayMember = "DescBanco";

            //}
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
                        gvProformaDisenioDetalle.AddNewRow();
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdPrestamoBanco", IdPrestamoBanco);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdPrestamoBancoDetalle", 0);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "NumeroCuota", NumeroCuota);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "FechaVencimiento", FechaVencimiento);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "SaldoPendiente", SaldoPendiente);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Amortizacion", Amortizacion);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Interes", Interes);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Desgravamen", Desgravamen);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Seguro", Seguro);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "TotalPagar", TotalPagar);
                        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "FlagEstado", true);
                        if (pOperacion == Operacion.Modificar)
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Consultar));

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
                lblTotalRegistros.Text = gvProformaDisenioDetalle.RowCount.ToString() + " Registros";



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

                for (int i = 0; i < gvProformaDisenioDetalle.RowCount; i++)
                {
                    intSituacion = Convert.ToInt32(gvProformaDisenioDetalle.GetRowCellValue(i, (gvProformaDisenioDetalle.Columns["IdSituacion"])));

                    decSaldo = Convert.ToDecimal(gvProformaDisenioDetalle.GetRowCellValue(i, (gvProformaDisenioDetalle.Columns["SaldoPendiente"])));
                    decInteres = Convert.ToDecimal(gvProformaDisenioDetalle.GetRowCellValue(i, (gvProformaDisenioDetalle.Columns["Interes"])));

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

        public class ProformaDisenioDetalle
        {
            public Int32 IdProformaDisenio { get; set; }
            public Int32 IdProformaDisenioDetalle { get; set; }
            public Int32 IdSituacionProducto { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 IdUnidadMedida { get; set; }
            public String Modelo { get; set; }
            public String Medida { get; set; }
            public String Material { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Precio { get; set; }
            public Decimal ValorVenta { get; set; }
            public String Observacion { get; set; }
            public Boolean FlagObsequio { get; set; }
            public Boolean FlagModificado { get; set; }
            public Boolean FlagAprobado { get; set; }
            public byte[] Imagen { get; set; }
            public DateTime? FechaEntrega { get; set; }
            public Int32 TipoOper { get; set; }

            public ProformaDisenioDetalle()
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           if (pOperacion == Operacion.Modificar)
               {
                if (gvProformaDisenioDetalle.RowCount > 0)
                {
                    if (XtraMessageBox.Show("¿Esta seguro de generar nuevamente los abonos? Esto borra los abonos anteriores.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        SolicitudEgresoBE objSolicitudEgreso = new SolicitudEgresoBE();
                        SolicitudEgresoBL objBL_SolicitudEgreso = new SolicitudEgresoBL();
                        objSolicitudEgreso.IdSolicitudEgreso = IdProformaDisenio;
                        objBL_SolicitudEgreso.Elimina(objSolicitudEgreso);

                        gvProformaDisenioDetalle.Focus();
                        gvProformaDisenioDetalle.SelectAll();
                        gvProformaDisenioDetalle.DeleteSelectedRows();

                        int nCuotas = 0;
                        //nCuotas = Convert.ToInt32(speFin.Value);
                        //if (nCuotas > 0)
                        //{
                        //    for (int i = 1; i <= nCuotas; i++)
                        //    {
                        //        gvProformaDisenioDetalle.AddNewRow();
                        //        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "NumAbono", i);
                        //        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "TipoOper", 1);
                        //    }
                        //}

                    }
                }
                else
                {
                    gvProformaDisenioDetalle.Focus();
                    gvProformaDisenioDetalle.SelectAll();
                    gvProformaDisenioDetalle.DeleteSelectedRows();

                    //if (pOperacion == Operacion.Nuevo)
                    //{
                        int nCuotas = 0;
                        //nCuotas = Convert.ToInt32(speFin.Value);
                        //if (nCuotas > 0)
                        //{
                        //    for (int i = 1; i <= nCuotas; i++)
                        //    {
                        //        gvProformaDisenioDetalle.AddNewRow();
                        //        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "NumAbono", i);
                        //    }
                        //}
                    //}

                }
               }
            else
            {
                gvProformaDisenioDetalle.Focus();
                gvProformaDisenioDetalle.SelectAll();
                gvProformaDisenioDetalle.DeleteSelectedRows();

                if (pOperacion == Operacion.Nuevo)
                {
                    int nCuotas = 0;
                    //nCuotas = Convert.ToInt32(speFin.Value);
                    //if (nCuotas > 0)
                    //{
                    //    for (int i = 1; i <= nCuotas; i++)
                    //    {
                    //        gvProformaDisenioDetalle.AddNewRow();
                    //        gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "NumAbono", i);
                    //    }
                    //}
                }
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
            if (e.KeyCode == Keys.Enter)
            {
                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR")
                            objE_Cliente.AbrevDomicilio = "";
                        else
                            objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion;  // + objE_Cliente.NumDireccion;
                        IdTipoCliente = objE_Cliente.IdTipoCliente;
                        txtCorreo.Text = objE_Cliente.Correo;
                        txtReferencia.Text = objE_Cliente.Referencia;

                        //if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        //    IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                        //cboDepartamento.EditValue = IdDepartamento;
                        //if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        //    IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                        //cboProvincia.EditValue = IdProvincia;
                        //if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        //    IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                        //cboDistrito.EditValue = IdDistrito;
                    }
                    else
                    {
                        if (XtraMessageBox.Show("El cliente no existe, desea registrar al nuevo cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            btnNuevoCliente_Click(sender, e);
                        }
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();

                if (frm.pClienteBE != null)
                {
                    if (frm.pClienteBE.AbrevDomicilio == "OTR") frm.pClienteBE.AbrevDomicilio = ""; else frm.pClienteBE.AbrevDomicilio = frm.pClienteBE.AbrevDomicilio + " ";

                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;

                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        DateTime FechaNac = frm.pClienteBE.FechaNac == null ? DateTime.Now.AddMonths(-1) : Convert.ToDateTime(frm.pClienteBE.FechaNac.ToString());
                        int PeriodoNac = FechaNac.Year;
                        int Anios = Parametros.intPeriodo - PeriodoNac;

                        //Compras del mes
                        List<DocumentoVentaBE> lstVenta = null;
                        lstVenta = new DocumentoVentaBL().ListaMesCumpleanos(Parametros.intPeriodo, FechaNac.Month, frm.pClienteBE.IdCliente);
                    }

                    string IdDepartamento = string.Empty;
                    string IdProvincia = string.Empty;
                    string IdDistrito = string.Empty;

                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, frm.pClienteBE.NumeroDocumento);
                    txtCorreo.Text = objE_Cliente.Correo;
                    txtReferencia.Text = objE_Cliente.Referencia;
                    if (objE_Cliente != null)
                    {
                        if (objE_Cliente.AbrevDomicilio == "OTR")
                            objE_Cliente.AbrevDomicilio = "";
                        else
                            objE_Cliente.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                        //if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        //    IdDepartamento = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                        //cboDepartamento.EditValue = IdDepartamento;
                        //if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        //    IdProvincia = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                        //cboProvincia.EditValue = IdProvincia;
                        //if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        //    IdDistrito = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                        //cboDistrito.EditValue = IdDistrito;
                    }

                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCuentaBancoProveedor_EditValueChanged(object sender, EventArgs e)
        {
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

        private void cboTipoEgreso_EditValueChanged(object sender, EventArgs e)
        {
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
        }

        private void txtNumeroDocumento_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //frmBusClienteSolicitud frm = new frmBusClienteSolicitud();
                //frm.pNumeroDescCliente = "";
                //frm.pFlagMultiSelect = false;
                //frm.ShowDialog();

                //if (frm.pClienteBE != null)
                //{
                //    IdCliente = frm.pClienteBE.IdCliente;
                //    txtAFacturar.Text = frm.pClienteBE.DescCliente;
                //}
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarVendedor2_Click(object sender, EventArgs e)
        {
            cboVendedor.EditValue = 0;
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    txtDescCliente.Text = objManCliente.DescCliente;
                    txtDireccion.Text = objManCliente.AbrevDocimicilio.Substring(0, 2) + ". " + objManCliente.Direccion + ' ' + objManCliente.NumDireccion + ' ' + objManCliente.DescDistrito + '-' + objManCliente.DescProvincia + '-' + objManCliente.DescDepartamento;//add
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        ClienteBE objE_Cliente2 = null;
                        objE_Cliente2 = new ClienteBL().SeleccionaNumeroAgenda(Parametros.intEmpresaId, objE_Cliente.NumeroDocumento.Trim());
                        txtCorreo.Text = objE_Cliente.Correo;
                        txtReferencia.Text = objE_Cliente.Referencia;

                        if (objE_Cliente2 != null)
                        {
                            if (objE_Cliente2.AbrevDomicilio == "OTR")
                                objE_Cliente2.AbrevDomicilio = "";
                            else
                                objE_Cliente2.AbrevDomicilio = objE_Cliente.AbrevDomicilio + " ";

                            IdCliente = objE_Cliente2.IdCliente;
                            txtNumeroDocumento.Text = objE_Cliente2.NumeroDocumento;
                            txtDescCliente.Text = objE_Cliente2.DescCliente;
                            txtDireccion.Text = objE_Cliente2.AbrevDomicilio + " " + objE_Cliente.Direccion;  // + objE_Cliente.NumDireccion;
                            IdTipoCliente = objE_Cliente2.IdTipoCliente;
                            txtCorreo.Text = objE_Cliente2.Correo;
                            txtReferencia.Text = objE_Cliente2.Referencia;

                            //if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                            //    IdDepartamento = objE_Cliente2.IdUbigeoDom.Substring(0, 2);
                            //cboDepartamento.EditValue = IdDepartamento;
                            //if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                            //    IdProvincia = objE_Cliente2.IdUbigeoDom.Substring(2, 2);
                            //cboProvincia.EditValue = IdProvincia;
                            //if (objE_Cliente2.IdUbigeoDom.Trim() != "")
                            //    IdDistrito = objE_Cliente2.IdUbigeoDom.Substring(4, 2);
                            //cboDistrito.EditValue = IdDistrito;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmProformaDisenioDetalle_Add movDetalle = new frmProformaDisenioDetalle_Add();
                movDetalle.pOperacion = frmProformaDisenioDetalle_Add.Operacion.Nuevo;
                movDetalle.StartPosition = FormStartPosition.CenterParent;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaProformaDisenioDetalleOrigen.Count == 0)
                        {
                            gvProformaDisenioDetalle.AddNewRow();
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdProformaDisenio", movDetalle.oBE.IdProformaDisenio);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdProformaDisenioDetalle", movDetalle.oBE.IdProformaDisenioDetalle);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdSituacionProducto", movDetalle.oBE.IdSituacionProducto);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Modelo", movDetalle.oBE.Modelo);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Medida", movDetalle.oBE.Medida);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Material", movDetalle.oBE.Material);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Imagen", movDetalle.oBE.Imagen);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "FlagModificado", movDetalle.oBE.FlagModificado);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProformaDisenioDetalle.UpdateCurrentRow();

                            CalculaTotales();
                            return;
                        }
                        if (mListaProformaDisenioDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaProformaDisenioDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvProformaDisenioDetalle.AddNewRow();
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdProformaDisenio", movDetalle.oBE.IdProformaDisenio);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdProformaDisenioDetalle", movDetalle.oBE.IdProformaDisenioDetalle);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdSituacionProducto", movDetalle.oBE.IdSituacionProducto);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Modelo", movDetalle.oBE.Modelo);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Medida", movDetalle.oBE.Medida);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Material", movDetalle.oBE.Material);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Precio", movDetalle.oBE.Precio);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Imagen", movDetalle.oBE.Imagen);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "FlagModificado", movDetalle.oBE.FlagModificado);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvProformaDisenioDetalle.SetRowCellValue(gvProformaDisenioDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProformaDisenioDetalle.UpdateCurrentRow();

                            CalculaTotales();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaProformaDisenioDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmProformaDisenioDetalle_Add movDetalle = new frmProformaDisenioDetalle_Add();

                movDetalle.pOperacion = frmProformaDisenioDetalle_Add.Operacion.Modificar;
                movDetalle.IdProformaDisenio = Convert.ToInt32(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdProformaDisenio"));
                movDetalle.IdProformaDisenioDetalle = Convert.ToInt32(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdProformaDisenioDetalle"));
                movDetalle.IdSituacionProducto = Convert.ToInt32(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdSituacionProducto"));
                movDetalle.IdProducto = Convert.ToInt32(gvProformaDisenioDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvProformaDisenioDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvProformaDisenioDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvProformaDisenioDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtModelo.Text = gvProformaDisenioDetalle.GetFocusedRowCellValue("Modelo").ToString();
                movDetalle.txtMedida.Text = gvProformaDisenioDetalle.GetFocusedRowCellValue("Medida").ToString();
                movDetalle.txtMaterial.Text = gvProformaDisenioDetalle.GetFocusedRowCellValue("Material").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvProformaDisenioDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvProformaDisenioDetalle.GetFocusedRowCellValue("Precio"));//mod
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvProformaDisenioDetalle.GetFocusedRowCellValue("Precio"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvProformaDisenioDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.bFlagModificado = Convert.ToBoolean(gvProformaDisenioDetalle.GetFocusedRowCellValue("FlagModificado"));
                movDetalle.bFlagObsequio = Convert.ToBoolean(gvProformaDisenioDetalle.GetFocusedRowCellValue("FlagObsequio"));
                movDetalle.sObservacion = gvProformaDisenioDetalle.GetFocusedRowCellValue("Observacion").ToString();
                movDetalle.Imagen = new FuncionBase().Bytes2Image((byte[])gvProformaDisenioDetalle.GetFocusedRowCellValue("Imagen"));

                movDetalle.StartPosition = FormStartPosition.CenterParent;

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvProformaDisenioDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "IdDis_ContratoFabricacion", movDetalle.oBE.IdProformaDisenio);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "IdDis_ContratoFabricacionDetalle", movDetalle.oBE.IdProformaDisenioDetalle);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "IdSituacionProducto", movDetalle.oBE.IdSituacionProducto);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Modelo", movDetalle.oBE.Modelo);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Medida", movDetalle.oBE.Medida);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Material", movDetalle.oBE.Material);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Precio", movDetalle.oBE.Precio);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Imagen", movDetalle.oBE.Imagen);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "FlagObsequio", movDetalle.oBE.FlagObsequio);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "FlagModificado", movDetalle.oBE.FlagModificado);
                        gvProformaDisenioDetalle.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);

                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvProformaDisenioDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvProformaDisenioDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvProformaDisenioDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                            gvProformaDisenioDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }
    }
}