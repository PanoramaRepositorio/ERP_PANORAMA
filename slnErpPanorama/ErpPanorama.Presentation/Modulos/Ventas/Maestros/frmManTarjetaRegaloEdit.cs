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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManTarjetaRegaloEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<TarjetaRegaloBE> lstTarjetaRegalo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TarjetaRegaloBE pTarjetaRegaloBE { get; set; }

        int _IdTarjetaRegalo = 0;

        public int IdTarjetaRegalo
        {
            get { return _IdTarjetaRegalo; }
            set { _IdTarjetaRegalo = value; }
        }

        int IdCliente = 0;
        private bool NumeracionAutomatica = true;
        private string Serie;
        private string Numero;
        #endregion

        #region "Eventos"
        public frmManTarjetaRegaloEdit()
        {
            InitializeComponent();
        }

        private void frmManTarjetaRegaloEdit_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionGiftCard), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = 0; // Parametros.intGiftCardActivo;
        //    cboSituacion.Enabled = false;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "GIFT CARD - Nuevo";
                IdCliente = 477159;
                txtNumeroDocumento.Text = "20330676826";
                txtDescCliente.Text = "PANORAMA DISTRIBUIDORES S.A.";


            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "GIFT CARD - Modificar";

                TarjetaRegaloBE objE_TarjetaRegalo = new TarjetaRegaloBE();

                objE_TarjetaRegalo = new TarjetaRegaloBL().Selecciona(IdTarjetaRegalo);
                cboTienda.EditValue = objE_TarjetaRegalo.IdTienda;
                txtNumero.Text = objE_TarjetaRegalo.Numero.Trim();
                IdCliente = objE_TarjetaRegalo.IdCliente;
                txtDescCliente.Text = objE_TarjetaRegalo.DescCliente;
                txtNumeroDocumento.Text = objE_TarjetaRegalo.NumeroDocumento;
                txtImporteTotal.EditValue = objE_TarjetaRegalo.ImporteTotal;
                txtImporteDisponible.EditValue = objE_TarjetaRegalo.ImporteDisponible;
                cboSituacion.EditValue = objE_TarjetaRegalo.IdSituacion;
                txtObservacion.Text = objE_TarjetaRegalo.Observacion;
                deDesde.EditValue = objE_TarjetaRegalo.FechaInicio;
                deHasta.EditValue = objE_TarjetaRegalo.FechaFin;

              //  txtNumero.Properties.ReadOnly = true;
                //txtImporteTotal.Properties.ReadOnly = true;
              //  txtImporteDisponible.Properties.ReadOnly = true;

            }

            txtNumero.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    TarjetaRegaloBL objBL_TarjetaRegalo = new TarjetaRegaloBL();
                    TarjetaRegaloBE objTarjetaRegalo = new TarjetaRegaloBE();

                    objTarjetaRegalo.IdTarjetaRegalo = IdTarjetaRegalo;
                    objTarjetaRegalo.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objTarjetaRegalo.IdCliente = IdCliente;
                    objTarjetaRegalo.Numero = txtNumero.Text;
                    objTarjetaRegalo.ImporteTotal = Convert.ToDecimal(txtImporteTotal.EditValue);
                    objTarjetaRegalo.ImporteDisponible = Convert.ToDecimal(txtImporteTotal.EditValue);   // Convert.ToDecimal(txtImporteDisponible.EditValue);
                    objTarjetaRegalo.FechaInicio = Convert.ToDateTime(deDesde.DateTime.ToShortDateString());
                    objTarjetaRegalo.FechaFin = Convert.ToDateTime(deHasta.DateTime.ToShortDateString());
                    objTarjetaRegalo.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                    objTarjetaRegalo.Observacion = txtObservacion.Text;
                    objTarjetaRegalo.FlagEstado = false;
                    objTarjetaRegalo.Usuario = Parametros.strUsuarioLogin;
                    objTarjetaRegalo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objTarjetaRegalo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_TarjetaRegalo.Inserta(objTarjetaRegalo);
                    else
                        objBL_TarjetaRegalo.Actualiza(objTarjetaRegalo);

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




        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            //if (txtNumero.Text.Trim().ToString() == "")
            //{
            //    strMensaje = strMensaje + "- Ingrese Número de Tarjeta.\n";
            //    flag = true;
            //}

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Ingrese Cliente.\n";
                flag = true;
            }

            //if (Convert.ToDecimal(txtImporteTotal.EditValue)==0)
            //{
            //    strMensaje = strMensaje + "NO EXISTE IMPORTE, SOLO SE REGISTRARA EL NUMERO DE LA TARJETA. SI DESEA HACER USO DE LA .\n TARJETA TENDRA QUE ADICIONAR SALDO .";
            //    flag = false;
            //}

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTarjetaRegalo.Where(oB => oB.Numero.ToUpper() == txtNumero.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La Tarjeta ya existe.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CobrarImprimir()
        {
            //if (Convert.ToDecimal(txtImporteTotal.Text) > 0)
            //{
            //    ////Validar Empresa 
            //    CajaEmpresaBE objCajaEmpresa = null;
            //    objCajaEmpresa = new CajaEmpresaBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId);

            //    if (objCajaEmpresa == null)
            //    {
            //        XtraMessageBox.Show("No se puede imprimir en esta Caja, Documentos de venta de: " + objCajaEmpresa.RazonSocial + ",  \nConsulte con su Administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    TipoFormato = objCajaEmpresa.IdTipoFormato;

            //    frmMsgPagoCondicion frmMsgPago = new frmMsgPagoCondicion();
            //    frmMsgPago.NumeroPedido = "";
            //    frmMsgPago.IdEmpresa = IdEmpresa;
            //    frmMsgPago.NumeroDocumento = txtNumeroDocumento.Text.Trim();
            //    frmMsgPago.DescCliente = txtDescCliente.Text;
            //    frmMsgPago.Direccion = txtDireccion.Text;
            //    frmMsgPago.Total = Convert.ToDecimal(txtTotal.Text);
            //    frmMsgPago.IdCliente = IdCliente;
            //    frmMsgPago.IdTipoDocumento = IdTipoDocumento;
            //    frmMsgPago.IdTipoCliente = IdTipoCliente;
            //    frmMsgPago.ShowDialog();

            //    if (frmMsgPago.DialogResult == DialogResult.OK)
            //    {
            //        IdEmpresa = frmMsgPago.IdEmpresa;
            //        NumeroCupon = frmMsgPago.NumeroCupon;
            //        Cupon = frmMsgPago.Cupon;

            //        EmpresaBE objE_Empresa = null;
            //        objE_Empresa = new EmpresaBL().Selecciona(IdEmpresa);
            //        if (objE_Empresa != null)
            //        {
            //            if (objE_Empresa.IdRegimenTributario == Parametros.intRegimenTributarioRUS)// solo Rus
            //            {
            //                bRegimenRus = true;

            //                if (!FlagImpresionRus) //add 160216
            //                {
            //                    XtraMessageBox.Show("No se puede imprimir una boleta RUS con promoción de 2x1 ó 3x2.\nDebe emitir el comprobante por:" + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                    return;
            //                }

            //                if (!ValidarTopeEmpresaRus()) //Mensual
            //                {
            //                    if (!ValidarTopeEmpresaDiarioRus()) //Diario
            //                    {
            //                        if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
            //                        {
            //                            InsertarDocumentoVentaPagoVariosRUS(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster);
            //                            //ImpresionDirecta("BOV");
            //                            this.Close();
            //                            return;
            //                        }
            //                        else
            //                        {
            //                            InsertarDocumentoVentaVariosPagoVariosRUS(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster);
            //                            //ImpresionDirecta("BOV");
            //                            this.Close();
            //                            return;
            //                        }
            //                    }
            //                    return;
            //                }
            //                return;
            //            }
            //        }

            //        //Panorama y RER
            //        //Obtener la serie del documento relacionado a la caja
            //        TalonBE objE_Talon = null;
            //        objE_Talon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);
            //        if (objE_Talon != null)
            //        {
            //            Serie = "";
            //            Serie = objE_Talon.NumeroSerie;
            //        }

            //        if (Serie == null)
            //        {
            //            XtraMessageBox.Show("El documento de venta no esta asignado a la caja, por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            Cursor = Cursors.Default;
            //            cboDocumento.Focus();
            //            return;
            //        }

            //        cboDocumento.EditValue = frmMsgPago.IdTipoDocumento;//Capturamos el valor
            //        string TipoDoc = cboDocumento.Text;
            //        if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocBoletaVenta) //CUANDO ES BOLETA DE VENTA
            //        {
            //            if (mListaDocumentoVentaDetalleOrigen.Count <= 6)
            //            {
            //                InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster, TipoDoc);
            //            }
            //            else
            //            {
            //                InsertarDocumentoVentaVariosPagoVarios(6, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster, TipoDoc);
            //            }
            //        }

            //        if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocFacturaVenta) //CUANDO ES FACTURA DE VENTA
            //        {
            //            if (mListaDocumentoVentaDetalleOrigen.Count <= 10)
            //            {
            //                InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster, TipoDoc);
            //            }
            //            else
            //            {
            //                InsertarDocumentoVentaVariosPagoVarios(10, frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster, TipoDoc);
            //            }
            //        }

            //        if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketBoleta)
            //        {
            //            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster, TipoDoc);
            //            // ImpresionDirecta("TKV");
            //        }
            //        if (Convert.ToInt32(frmMsgPago.IdTipoDocumento) == Parametros.intTipoDocTicketFactura)
            //        {
            //            InsertarDocumentoVentaPagoVarios(frmMsgPago.Efectivo, frmMsgPago.Visa, frmMsgPago.MasterCard, frmMsgPago.VisaPuntosVida, frmMsgPago.MasterCardPuntosVida, frmMsgPago.VisaTipoTarjeta, frmMsgPago.MasterTipoTarjeta, frmMsgPago.NumeroNotaCredito, frmMsgPago.IdTipoMaster, TipoDoc);
            //            // ImpresionDirecta("TKF");
            //        }
            //        this.Close();
            //    }

            //}
            //else
            //{
            //    XtraMessageBox.Show("No se puede cobrar con monto cero, verificar venta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        //private void InsertarDocumentoVentaPagoVarios(decimal Efectivo, decimal Visa, decimal MasterCard, decimal VisaPuntosVida, decimal MasterCardPuntosVida, string TipoVisa, string TipoMaster, string NumeroNotaCredito, int IdTipoMaster, int IdTipoDocumento)
        //{
        //    try
        //    {
               
        //        //Generamos el documento cabecera.
        //        DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
        //        DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

        //        objDocumentoVenta.IdDocumentoVenta = 0;
        //        objDocumentoVenta.IdTienda = Parametros.intTiendaId;
        //        objDocumentoVenta.IdPedido = null;
        //        objDocumentoVenta.Periodo = Parametros.intPeriodo;
        //        objDocumentoVenta.Mes = DateTime.Now.Month;
        //        objDocumentoVenta.IdTipoDocumento = IdTipoDocumento;

        //        //Obtener la serie del documento relacionado a la caja
        //        if (NumeracionAutomatica == true) //Add 13-03-15
        //        {
        //            TalonBE objE_Talon = null;
        //            objE_Talon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);
        //            if (objE_Talon != null)
        //            {
        //                Serie = "";
        //                Serie = objE_Talon.NumeroSerie;
        //            }
        //        }

        //        //Obtener el numero del documento relacionado a la serie
        //        List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
        //        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Parametros.intEmpresaId, IdTipoDocumento, txtSerie.Text);
        //        if (mListaNumero.Count > 0)
        //        {
        //            Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
        //        }

        //        #region "Verificar Número"

        //        DocumentoVentaBE objE_DocumentoVentaSerie = null;
        //        objE_DocumentoVentaSerie = objBL_DocumentoVenta.SeleccionaSerieNumero(Parametros.intEmpresaId, objDocumentoVenta.IdTipoDocumento, Serie, Numero);
        //        if (objE_DocumentoVentaSerie != null)
        //        {
        //            XtraMessageBox.Show("El documento " + IdTipoDocumento.ToString() + ":" + Serie + "-" + Numero + " ya existe, Por favor verificar el correlativo de la serie:" + Serie, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        #endregion

        //        objDocumentoVenta.Serie = Serie;
        //        objDocumentoVenta.Numero = Numero;
        //        objDocumentoVenta.IdDocumentoReferencia = null;
        //        objDocumentoVenta.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //        objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(DateTime.Now.ToShortDateString()); //Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //        objDocumentoVenta.IdCliente = IdCliente;
        //        objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
        //        objDocumentoVenta.DescCliente = txtDescCliente.Text;
        //        objDocumentoVenta.Direccion = "Lima - Lima - Lima"; //txtDireccion.Text;
        //        objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
        //        objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
        //        objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
        //        objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
        //        objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
        //        objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
        //        objDocumentoVenta.PorcentajeDescuento = 0;
        //        objDocumentoVenta.Descuento = 0;
        //        objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
        //        objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
        //        objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
        //        objDocumentoVenta.TotalBruto = Convert.ToDecimal(txtTotalBruto.EditValue);
        //        objDocumentoVenta.Observacion = "DOC. GENERADO  POR AUTOSERVICIO | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
        //        objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
        //        objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
        //        objDocumentoVenta.FlagEstado = true;
        //        objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
        //        objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //        objDocumentoVenta.IdEmpresa = Parametros.intEmpresaId;
        //        objDocumentoVenta.IdAlmacen = Parametros.intAlmTienda;

        //        //Documento Vneta Detalle
        //        List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

        //        foreach (var item in mListaDocumentoVentaDetalleOrigen)
        //        {
        //            DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
        //            objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
        //            objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
        //            objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
        //            objE_DocumentoVentaDetalle.Item = item.Item;
        //            objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
        //            objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
        //            objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
        //            objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
        //            objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
        //            objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
        //            objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
        //            objE_DocumentoVentaDetalle.Descuento = item.Descuento;
        //            objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
        //            objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
        //            objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
        //            objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
        //            objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
        //            objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
        //            objE_DocumentoVentaDetalle.FlagEstado = true;
        //            objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
        //            lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
        //        }


        //        //Movimiento Caja
        //        List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

        //        if (Efectivo > 0 || (Efectivo == 0 && Visa == 0 && MasterCard == 0 && VisaPuntosVida == 0 && MasterCardPuntosVida == 0 && Cupon == 0))
        //        {
        //            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
        //            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
        //            objE_MovimientoCaja.IdMovimientoCaja = 0;
        //            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
        //            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //            objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
        //            objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
        //            objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
        //            objE_MovimientoCaja.IdCondicionPago = 98;//
        //            objE_MovimientoCaja.TipoTarjeta = null;
        //            objE_MovimientoCaja.TipoMovimiento = "I";
        //            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
        //            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.ImporteSoles = Efectivo;
        //            objE_MovimientoCaja.ImporteDolares = Efectivo / Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.FlagEstado = true;
        //            lstMovimientoCaja.Add(objE_MovimientoCaja);
        //        }
        //        if (Visa > 0)
        //        {
        //            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
        //            objE_MovimientoCaja.IdMovimientoCaja = 1;
        //            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
        //            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //            objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
        //            objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
        //            objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
        //            objE_MovimientoCaja.IdCondicionPago = 99;
        //            objE_MovimientoCaja.TipoTarjeta = TipoVisa;
        //            objE_MovimientoCaja.TipoMovimiento = "I";
        //            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
        //            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.ImporteSoles = Visa;
        //            objE_MovimientoCaja.ImporteDolares = Visa / Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.FlagEstado = true;
        //            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
        //            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
        //            lstMovimientoCaja.Add(objE_MovimientoCaja);
        //        }
        //        if (MasterCard > 0)
        //        {
        //            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
        //            objE_MovimientoCaja.IdMovimientoCaja = 2;
        //            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
        //            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //            objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
        //            objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
        //            objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
        //            objE_MovimientoCaja.IdCondicionPago = IdTipoMaster;// 100;
        //            objE_MovimientoCaja.TipoTarjeta = TipoMaster;
        //            objE_MovimientoCaja.TipoMovimiento = "I";
        //            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
        //            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.ImporteSoles = MasterCard;
        //            objE_MovimientoCaja.ImporteDolares = MasterCard / Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.FlagEstado = true;
        //            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
        //            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //            objE_MovimientoCaja.IdEmpresa = Parametros.intEmpresaId;
        //            lstMovimientoCaja.Add(objE_MovimientoCaja);
        //        }

        //        if (VisaPuntosVida > 0) //--------------------------------------------------------add
        //        {
        //            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
        //            objE_MovimientoCaja.IdMovimientoCaja = 3;
        //            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
        //            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //            objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
        //            objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
        //            objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
        //            objE_MovimientoCaja.IdCondicionPago = Parametros.intVisaPuntosVida;
        //            objE_MovimientoCaja.TipoTarjeta = TipoVisa;
        //            objE_MovimientoCaja.TipoMovimiento = "I";
        //            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
        //            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.ImporteSoles = VisaPuntosVida;
        //            objE_MovimientoCaja.ImporteDolares = VisaPuntosVida / Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.FlagEstado = true;
        //            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
        //            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //            objE_MovimientoCaja.IdEmpresa = IdEmpresa;
        //            lstMovimientoCaja.Add(objE_MovimientoCaja);
        //        }
        //        if (MasterCardPuntosVida > 0) //--------------------------------------------------------
        //        {
        //            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
        //            objE_MovimientoCaja.IdMovimientoCaja = 4;
        //            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
        //            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //            objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
        //            objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
        //            objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
        //            objE_MovimientoCaja.IdCondicionPago = Parametros.intMasterCardPuntosVida; ;
        //            objE_MovimientoCaja.TipoTarjeta = TipoMaster;
        //            objE_MovimientoCaja.TipoMovimiento = "I";
        //            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
        //            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.ImporteSoles = MasterCardPuntosVida;
        //            objE_MovimientoCaja.ImporteDolares = MasterCardPuntosVida / Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.FlagEstado = true;
        //            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
        //            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //            objE_MovimientoCaja.IdEmpresa = IdEmpresa;
        //            lstMovimientoCaja.Add(objE_MovimientoCaja);
        //        }
        //        if (Cupon > 0) //--------------------------------------------------------
        //        {
        //            MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
        //            objE_MovimientoCaja.IdMovimientoCaja = 4;
        //            objE_MovimientoCaja.IdCaja = Parametros.intCajaId;
        //            objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //            objE_MovimientoCaja.IdTipoDocumento = IdTipoDocumento;
        //            objE_MovimientoCaja.NumeroDocumento = Serie + "-" + Numero;
        //            objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
        //            objE_MovimientoCaja.IdCondicionPago = Parametros.intCupon; ;
        //            objE_MovimientoCaja.NumeroCondicion = NumeroCupon;
        //            objE_MovimientoCaja.TipoTarjeta = null;
        //            objE_MovimientoCaja.TipoMovimiento = "I";
        //            objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
        //            objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.ImporteSoles = Cupon;
        //            objE_MovimientoCaja.ImporteDolares = Cupon / Convert.ToDecimal(txtTC.EditValue);
        //            objE_MovimientoCaja.FlagEstado = true;
        //            objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
        //            objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
        //            objE_MovimientoCaja.IdEmpresa = IdEmpresa;
        //            lstMovimientoCaja.Add(objE_MovimientoCaja);
        //        }

        //        //Documento Venta Pago
        //        List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
        //        if (mListaDocumentoVentaPagoOrigen.Count == 0)
        //        {
        //            DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
        //            objE_Pago.IdEmpresa = Parametros.intEmpresaId;
        //            objE_Pago.IdDocumentoVenta = 0;
        //            objE_Pago.IdDocumentoVentaPago = 0;
        //            objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
        //            objE_Pago.IdTipoDocumento = IdTipoDocumento;
        //            objE_Pago.NumeroDocumento = Serie + "-" + Numero;
        //            objE_Pago.IdCondicionPago = Convert.ToInt32(cboCondicionPago.EditValue);
        //            objE_Pago.IdMoneda = Convert.ToInt32(cboMonedaPago.EditValue);
        //            objE_Pago.TipoCambio = Convert.ToDecimal(txtTC.EditValue);
        //            objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
        //            objE_Pago.FlagEstado = true;
        //            objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
        //            lstDocumentoVentaPago.Add(objE_Pago);
        //        }
        //        else
        //        {
        //            foreach (var item in mListaDocumentoVentaPagoOrigen)
        //            {
        //                DocumentoVentaPagoBE objE_DocumentoVentaPago = new DocumentoVentaPagoBE();
        //                objE_DocumentoVentaPago.IdEmpresa = item.IdEmpresa;
        //                objE_DocumentoVentaPago.IdDocumentoVenta = item.IdDocumentoVenta;
        //                objE_DocumentoVentaPago.IdDocumentoVentaPago = item.IdDocumentoVentaPago;
        //                objE_DocumentoVentaPago.Fecha = item.Fecha;
        //                objE_DocumentoVentaPago.IdTipoDocumento = item.IdTipoDocumento;
        //                objE_DocumentoVentaPago.CodTipoDocumento = item.CodTipoDocumento;
        //                objE_DocumentoVentaPago.NumeroDocumento = Serie + "-" + Numero;
        //                objE_DocumentoVentaPago.IdCondicionPago = item.IdCondicionPago;
        //                objE_DocumentoVentaPago.DescCondicionPago = item.DescCondicionPago;
        //                objE_DocumentoVentaPago.IdMoneda = item.IdMoneda;
        //                objE_DocumentoVentaPago.CodMoneda = item.CodMoneda;
        //                objE_DocumentoVentaPago.TipoCambio = item.TipoCambio;
        //                objE_DocumentoVentaPago.Importe = item.Importe;
        //                objE_DocumentoVentaPago.FlagEstado = true;
        //                objE_DocumentoVentaPago.TipoOper = item.TipoOper;
        //                lstDocumentoVentaPago.Add(objE_DocumentoVentaPago);
        //            }
        //        }

        //        if (pOperacion == Operacion.Nuevo)
        //        {
        //            int IdDocumentoVenta = 0;
        //            IdDocumentoVenta = objBL_DocumentoVenta.InsertaDocumentoContadoPagoVariosAutoservicios(objDocumentoVenta, lstDocumentoVentaDetalle, lstMovimientoCaja, lstDocumentoVentaPago, NumeroNotaCredito, NumeracionAutomatica);
        //            ImpresionContinua(IdDocumentoVenta);

        //        }
        //        else
        //        {
        //            XtraMessageBox.Show("Edición no Disponible", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}



        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                //objManClientel.lstCliente = mLista;
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    txtDescCliente.Text = objManCliente.DescCliente;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImporteTotal_EditValueChanged(object sender, EventArgs e)
        {
            txtImporteDisponible.Text = txtImporteTotal.Text;

        }
    }
}