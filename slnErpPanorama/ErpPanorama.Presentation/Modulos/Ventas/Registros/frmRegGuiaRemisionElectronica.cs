using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Funciones;
using System.Security.Principal;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegGuiaRemisionElectronica : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();

        private int IdCliente = 0;
        public int IdOrigen = 0; //0=Facturación, 1=nota de Salida
        public int IdDocumentoVenta = 0;
        public int IdMovimientoAlmacen = 0;

        public int IdtiendaDestinoGuia = 0;
        public string UbigeoDestinoGuia = "";
        #endregion

        #region "Eventos"
        public frmRegGuiaRemisionElectronica()
        {
            InitializeComponent();
        }

        private void frmRegGuiaRemisionElectronica_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            BSUtils.LoaderLook(cboTipoDocumentoTra, CargarTipoDocumento(), "Descripcion", "Id", false);
            cboTipoDocumentoTra.EditValue = 1;
            BSUtils.LoaderLook(cboModalidad, CargarModalidad(), "Descripcion", "Id", false);
            cboModalidad.EditValue = "02";
            BSUtils.LoaderLook(cboMotivoTraslado, CargarMotivoTraslado(), "Descripcion", "Id", false);
            cboMotivoTraslado.EditValue = "01";

            BSUtils.LoaderLook(cboDocumentoOrigen, CargarDocumentoOrigen(), "Descripcion", "Id", false);
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

            BSUtils.LoaderLook(cboVehiculo, new VehiculoBL().ListaTodosActivo(0), "Placa", "IdVehiculo", true);
            cboVehiculo.EditValue =3;

            if (IdOrigen == 0)
            {
                DocumentoVentaBE objE_DocumentoVenta = null;
                objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);

                IdCliente = objE_DocumentoVenta.IdCliente;
                cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;

                if (objE_DocumentoVenta.IdEmpresa == 3) //CORONA IMPORTADORES E.I.R.L.
                {
                    cboTienda.EditValue = 14;
                }
                else if (objE_DocumentoVenta.IdEmpresa == 8)
                {
                    cboTienda.EditValue = 17;
                }
                else if (objE_DocumentoVenta.IdEmpresa == 19)
                {
                    cboTienda.EditValue = 13;
                }
                else if (objE_DocumentoVenta.IdEmpresa == 20)
                {
                    cboTienda.EditValue = 18;
                }
                else if (objE_DocumentoVenta.IdEmpresa == 23)
                {
                    cboTienda.EditValue = 16;
                }
                else if (objE_DocumentoVenta.IdEmpresa == 21)
                {
                    cboTienda.EditValue = 12;
                }
                else
                { cboTienda.EditValue = objE_DocumentoVenta.IdTienda; }

                txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                txtDireccion.Text = objE_DocumentoVenta.Direccion;

                if (objE_DocumentoVenta.IdUbigeo != null)
                {
                    if (objE_DocumentoVenta.IdUbigeo.Trim() != "")
                        cboDepartamento.EditValue = objE_DocumentoVenta.IdUbigeo.Substring(0, 2);
                    if (objE_DocumentoVenta.IdUbigeo.Trim() != "")
                        cboProvincia.EditValue = objE_DocumentoVenta.IdUbigeo.Substring(2, 2);
                    if (objE_DocumentoVenta.IdUbigeo.Trim() != "")
                        cboDistrito.EditValue = objE_DocumentoVenta.IdUbigeo.Substring(4, 2);
                }
                if(objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica)
                    txtGlosa.Text = $"BOLETA: {objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}";
                else if (objE_DocumentoVenta.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                    txtGlosa.Text = $"FACTURA: {objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}";
                else
                    txtGlosa.Text = $"OTRO DOC: {objE_DocumentoVenta.Serie}-{objE_DocumentoVenta.Numero}";

            }
            else
            {
                MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId, IdMovimientoAlmacen);

                IdCliente = 147586; //Panorama Distribuidores
                cboEmpresa.EditValue = Parametros.intPanoraramaDistribuidores ;
                cboTienda.EditValue = Parametros.intTiendaUcayali;
                txtNumeroDocumento.Text = "20330676826";
                txtDescCliente.Text = "PANORAMA DISTRIBUIDORES S.A.";
                txtDireccion.Text = "JR. UCAYALI 425 - LIMA";
                cboDepartamento.EditValue = "15";
                cboProvincia.EditValue = "01";
                cboDistrito.EditValue = "01";
                txtGlosa.Text = $"N/S: {objE_MovimientoAlmacen.Numero}";
            }

            CargaDocumentoVentaDetalle();
        }

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    if (txtNumeroDocumento.Text.Trim().Length != frm.pClienteBE.NumeroDocumento.Length)
                    {
                        XtraMessageBox.Show("No se puede cambiar de un RUC a Dni o Viceversa. Consulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;

                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                    if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        cboDepartamento.EditValue = objE_Cliente.IdUbigeoDom.Substring(0, 2);
                    if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        cboProvincia.EditValue = objE_Cliente.IdUbigeoDom.Substring(2, 2);
                    if (objE_Cliente.IdUbigeoDom.Trim() != "")
                        cboDistrito.EditValue = objE_Cliente.IdUbigeoDom.Substring(4, 2);
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarIngreso())
            {
                TiendaBE objBE_Tienda = new TiendaBE();
                objBE_Tienda = new TiendaBL().Selecciona(Convert.ToInt32(cboTienda.EditValue));
                if (objBE_Tienda.IdEmpresa==3)
                {
                    objBE_Tienda.Direccion = "JR. UCAYALI 425 CERCADO DE LIMA";
                }
                //Generamos el documento cabecera.
                DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                objDocumentoVenta.IdDocumentoVenta = 0;
                objDocumentoVenta.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                objDocumentoVenta.IdPedido = null;//IdPedido == 0 ? (int?)null : IdPedido;
                objDocumentoVenta.NumeroPedido = "";// txtNumeroPedido.Text;
                objDocumentoVenta.Periodo = Parametros.intPeriodo;
                objDocumentoVenta.Mes = deFecha.DateTime.Month;
                objDocumentoVenta.IdTipoDocumento = Parametros.intTipoDocGuiaElectronica;

                string Numero = "";
                string Serie = "";
                //Obtener el numero del documento relacionado a la serie
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo);
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue), Parametros.intTipoDocGuiaElectronica, true, Parametros.intPeriodo);//)txtSerie.Text);
                if (mListaNumero.Count > 0)
                {
                    Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                    Serie = mListaNumero[0].Serie;
                }
                else
                {
                    XtraMessageBox.Show("No existe una serie asignada para " + cboTienda.Text + ". Por favor comunicarse con el área de Contabilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                objDocumentoVenta.Serie = Serie;
                objDocumentoVenta.Numero = Numero;
                objDocumentoVenta.IdDocumentoReferencia = null;// cboDocumentoReferencia.EditValue == null ? (int?)null : IdDocumentoReferencia;
                objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFechaEnvio.DateTime.ToShortDateString());
                objDocumentoVenta.IdCliente = IdCliente;
                objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                objDocumentoVenta.DescCliente = txtDescCliente.Text;
                objDocumentoVenta.Direccion = txtDireccion.Text;
                objDocumentoVenta.IdMoneda = Parametros.intSoles;
                objDocumentoVenta.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                objDocumentoVenta.TipoCambioPedido = Convert.ToDecimal(Parametros.dmlTCMayorista);
                objDocumentoVenta.IdFormaPago = Parametros.intContado;
                objDocumentoVenta.DescFormaPago = "CONTADO";
                objDocumentoVenta.IdVendedor = Parametros.intPersonaId; //Convert.ToInt32(cboVendedor.EditValue);
                objDocumentoVenta.TotalCantidad = 0;// Convert.ToInt32(txtTotalCantidad.EditValue);
                objDocumentoVenta.SubTotal = 0; //Convert.ToDecimal(txtSubTotal.EditValue);
                //objDocumentoVenta.PorcentajeDescuento = Convert.ToDecimal(txtDescuento.EditValue);
                objDocumentoVenta.PorcentajeDescuento = 0;// Math.Round(Convert.ToDecimal(txtDescuento.EditValue), 2);//ADD 2011
                objDocumentoVenta.Descuentos = 0;
                objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                objDocumentoVenta.Igv = 0;// Convert.ToDecimal(txtImpuesto.EditValue);
                objDocumentoVenta.Total = 0;// Convert.ToDecimal(txtTotal.EditValue);
                objDocumentoVenta.TotalBruto = 0;// Convert.ToDecimal(txtTotalBruto.EditValue);
                objDocumentoVenta.Observacion = txtGlosa.Text + " - " + Parametros.strUsuarioLogin + " - " + WindowsIdentity.GetCurrent().Name.ToString(); // "DOCUMENTO DE VENTA GENERADO POR FACTURACIÓN";
                objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                objDocumentoVenta.CodigoNC = null;// CodigoNC;
                objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                objDocumentoVenta.FlagEstado = true;
                objDocumentoVenta.IdCambio = 0;// IdCambio;
                objDocumentoVenta.NumeroDevolucion = "";//NumeroDevolucion;
                objDocumentoVenta.TotalVentaDolares = 0;// decTotalVentaDolares;
                objDocumentoVenta.IdMotivo = Parametros.intMotivoVenta; //Convert.ToInt32(cboMotivo.EditValue);
                objDocumentoVenta.IdUsuario = Parametros.intUsuarioId;
                objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objDocumentoVenta.IdAlmacen = Parametros.intAlmCentralUcayali;

                objDocumentoVenta.IdUbigeoOrigen = objBE_Tienda.IdUbigeo;// "150101";//UCAYALI
                objDocumentoVenta.FechaTraslado = Convert.ToDateTime(deFechaEnvio.DateTime);

                // Motivo Traslado
                if (cboMotivoTraslado.EditValue.ToString()=="04")
                {
                    objDocumentoVenta.IdTiendaDestinoGuia = IdtiendaDestinoGuia;   //a la tienda de destino  (1)
                    objDocumentoVenta.IdUbigeo = UbigeoDestinoGuia; // cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objDocumentoVenta.MotivoTraslado = cboMotivoTraslado.EditValue.ToString();
                }
                else
                {
                    objDocumentoVenta.IdTiendaDestinoGuia = 0;  // venta a clientes  (1)
                    objDocumentoVenta.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objDocumentoVenta.MotivoTraslado = cboMotivoTraslado.EditValue.ToString();
                }

                objDocumentoVenta.ModalidadTraslado = cboModalidad.EditValue.ToString();
                objDocumentoVenta.NumeroBultos = Convert.ToInt32(txtNumeroBultos.EditValue);
                objDocumentoVenta.PesoBultos = Convert.ToInt32(txtPesoBultos.EditValue);
                objDocumentoVenta.IdTipoIdentidadTra = cboTipoDocumentoTra.EditValue.ToString();
                objDocumentoVenta.NumeroDocTra = txtNumeroDocTra.Text.Trim();
                objDocumentoVenta.RazonSocialTra = txtRazonSocialTra.Text.Trim();

                objDocumentoVenta.NumeroPlaca = cboVehiculo.Text.ToString(); // txtMarca.Text;
                objDocumentoVenta.Marca = txtMarca.Text.ToString(); // txtMarca.Text; (2)
                objDocumentoVenta.LicenciaConducir = txtLicencia.Text.ToString(); //  (3)

                //Documento Vneta Detalle
                List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = null;
                lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                    objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                    objE_DocumentoVentaDetalle.Item = item.Item;
                    objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                    objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                    objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                    objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                    objE_DocumentoVentaDetalle.CodAfeIGV = item.CodAfeIGV;
                    objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                    objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                    objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                    objE_DocumentoVentaDetalle.IdPromocion = item.IdPromocion;
                    objE_DocumentoVentaDetalle.FlagEstado = true;
                    objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                    lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                }

                //if (pOperacion == Operacion.Nuevo)
                //{
                IdDocumentoVenta = objBL_DocumentoVenta.Inserta(objDocumentoVenta, lstDocumentoVentaDetalle);




                #region "Grabar"
                //if (Parametros.bOnlineBoletaElectronica)
                //{
                //    string MensajeService = FacturaE.GrabarVentaIntegrens(IdDocumentoVenta);
                //    if (MensajeService.ToUpper() != "OK")
                //        XtraMessageBox.Show("Se ha producido un error al enviar el documento. Consulte con su Administrador\n" + MensajeService, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                #endregion

                #region "Impresión"
                ImpresionElectronicaLocal_Guias(objDocumentoVenta.IdEmpresa, IdDocumentoVenta, Parametros.intTipoDocGuiaElectronica, "A4");
                //ImpresionTicketElectronico("C");
                #endregion


                //}
                //else
                //{
                //    objBL_DocumentoVenta.Actualiza(objDocumentoVenta, lstDocumentoVentaDetalle);
                //}
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                gvDocumentoDetalle.AddNewRow();
                gvDocumentoDetalle.SetRowCellValue(gvDocumentoDetalle.FocusedRowHandle, "Item", (mListaDocumentoVentaDetalleOrigen.Count - 1) + 1);
                gvDocumentoDetalle.SetRowCellValue(gvDocumentoDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(1));

                gvDocumentoDetalle.FocusedColumn = gvDocumentoDetalle.GetVisibleColumn(1);
                gvDocumentoDetalle.ShowEditor();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdDocumentoDetalle = 0;
                        IdDocumentoDetalle = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle").ToString());
                        //if (gvDocumentoDetalle.GetFocusedRowCellValue("IdPedidoDetalle") != null)
                        //    IdDocumentoDetalle = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle").ToString());
                        int Item = 0;
                        if (gvDocumentoDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvDocumentoDetalle.GetFocusedRowCellValue("Item").ToString());

                        //objBL_DocumentoVentaDetalle.Elimina(objBE_DocumentoVentaDetalle);//Logico
                        //mListaDocumentoVentaDetalleOrigen.RemoveAt(gvDocumentoDetalle.FocusedRowHandle);
                        gvDocumentoDetalle.DeleteRow(gvDocumentoDetalle.FocusedRowHandle);
                        gvDocumentoDetalle.RefreshData();

                        //RegeneraItem
                        int i = 0;
                        int cuenta = 0;
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            item.Item = Convert.ToInt32(cuenta + 1);
                            cuenta++;
                            i++;
                        }
                    }
                    else
                    {
                        gvDocumentoDetalle.DeleteRow(gvDocumentoDetalle.FocusedRowHandle);
                        gvDocumentoDetalle.RefreshData();
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }
        }

        private void txtNumeroOrigen_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (txtNumeroOrigen.Text.Trim().Length > 0)
                {
                    SeteaMovimientoDetalle();
                    if (Convert.ToInt32(cboDocumentoOrigen.EditValue) == Parametros.intTipoDocPedidoVenta)
                    {
                        #region "Pedido"

                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroOrigen.Text.Trim());

                        if (objE_Pedido != null)
                        {
                            //Cargar aquí información de pedido
                            IdCliente = objE_Pedido.IdCliente;
                            cboEmpresa.EditValue = Parametros.intPanoraramaDistribuidores;
                            cboTienda.EditValue = Parametros.intTiendaId;
                            txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                            txtDescCliente.Text = objE_Pedido.DescCliente;
                            txtDireccion.Text = objE_Pedido.Direccion;
                            cboDepartamento.EditValue = 0;
                            //cboDepartamento.EditValue = "15";
                            //cboProvincia.EditValue = "01";
                            //cboDistrito.EditValue = "01";
                            txtGlosa.Text = $"PED: {objE_Pedido.Numero}";
                            cboDistrito.EditValue = "00";

                            //Cargar Detalle
                            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(objE_Pedido.IdPedido);

                            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                            {
                                CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                                objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                                objE_DocumentoDetalle.IdDocumentoVenta = 0;
                                objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;//item.IdDocumentoVentaDetalle;
                                objE_DocumentoDetalle.Item = item.Item;
                                objE_DocumentoDetalle.IdProducto = item.IdProducto;
                                objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                                objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                                objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                                objE_DocumentoDetalle.Cantidad = item.Cantidad;
                                objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                                objE_DocumentoDetalle.PrecioUnitario = 0;// item.PrecioUnitario;
                                objE_DocumentoDetalle.PorcentajeDescuento = 0;// item.PorcentajeDescuento;
                                objE_DocumentoDetalle.Descuento = 0; // item.Descuento;
                                objE_DocumentoDetalle.PrecioVenta = 0; //item.PrecioVenta;
                                objE_DocumentoDetalle.ValorVenta = 0; // item.ValorVenta;
                                objE_DocumentoDetalle.CodAfeIGV = "10";// item.CodAfeIGV;
                                objE_DocumentoDetalle.IdKardex = 0;// item.IdKardex;
                                objE_DocumentoDetalle.FlagMuestra = false;//item.FlagMuestra;
                                objE_DocumentoDetalle.FlagRegalo = false; //item.FlagRegalo;
                                objE_DocumentoDetalle.IdPromocion = null; //item.IdPromocion;
                                objE_DocumentoDetalle.Stock = 0;
                                objE_DocumentoDetalle.TipoOper = item.TipoOper;
                                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                            }

                            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                            gcDocumentoDetalle.DataSource = bsListado;
                            gcDocumentoDetalle.RefreshDataSource();
                        }
                        else
                        {
                            XtraMessageBox.Show("El Número de pedido no existe!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }
                    else if (Convert.ToInt32(cboDocumentoOrigen.EditValue) == Parametros.intTipoDocNotaSalida)
                    {
                        #region "Nota de Salida"

                        //Cargar 
                        List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
                        lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaNumero(Parametros.intEmpresaId, Parametros.intPeriodo, Parametros.intTipMovSalida, txtNumeroOrigen.Text.Trim());

                        if (lstMovimientoAlmacenDetalle.Count == 0)
                        {
                            XtraMessageBox.Show("La nota de salida no tiene códigos, Verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                        objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId, lstMovimientoAlmacenDetalle[0].IdMovimientoAlmacen);

                        IdCliente = 147586; //Panorama Distribuidores
                        cboEmpresa.EditValue = Parametros.intPanoraramaDistribuidores;
                        cboTienda.EditValue = Parametros.intTiendaId;
                        txtNumeroDocumento.Text = "20330676826";
                        txtDescCliente.Text = "PANORAMA DISTRIBUIDORES S.A.";

                        //Dirección del destino
                        AlmacenBE objBE_Almacen = new AlmacenBE();
                        objBE_Almacen = new AlmacenBL().Selecciona(Convert.ToInt32(objE_MovimientoAlmacen.IdAlmacenDestino));
                        IdtiendaDestinoGuia = objBE_Almacen.IdTienda;

                         TiendaBE objBE_Tienda = new TiendaBE();
                        objBE_Tienda = new TiendaBL().Selecciona(objBE_Almacen.IdTienda);
                        txtDireccion.Text = objBE_Tienda.Direccion;
                        cboDepartamento.EditValue = objBE_Tienda.IdUbigeo.Substring(0, 2);
                        cboProvincia.EditValue = objBE_Tienda.IdUbigeo.Substring(2, 2);
                        cboDistrito.EditValue = objBE_Tienda.IdUbigeo.Substring(4, 2);
                        UbigeoDestinoGuia = objBE_Tienda.IdUbigeo.Substring(0, 2) + objBE_Tienda.IdUbigeo.Substring(2, 2) + objBE_Tienda.IdUbigeo.Substring(4, 2);
                        //cboDepartamento.EditValue = "15";
                        //cboProvincia.EditValue = "01";
                        //cboDistrito.EditValue = "01";
                        txtGlosa.Text = $"N/S: {txtNumeroOrigen.Text}";
                        cboMotivoTraslado.EditValue = "04";

                        ////Cargar detalle
                        //List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
                        //lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdMovimientoAlmacen);

                        foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
                        {
                            CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdDocumentoVenta = 0;
                            objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;//item.IdDocumentoVentaDetalle;
                            objE_DocumentoDetalle.Item = item.Item;
                            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle.Cantidad = item.Cantidad;
                            objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                            objE_DocumentoDetalle.PrecioUnitario = 0;// item.PrecioUnitario;
                            objE_DocumentoDetalle.PorcentajeDescuento = 0;// item.PorcentajeDescuento;
                            objE_DocumentoDetalle.Descuento = 0; // item.Descuento;
                            objE_DocumentoDetalle.PrecioVenta = 0; //item.PrecioVenta;
                            objE_DocumentoDetalle.ValorVenta = 0; // item.ValorVenta;
                            objE_DocumentoDetalle.CodAfeIGV = "10";// item.CodAfeIGV;
                            objE_DocumentoDetalle.IdKardex = 0;// item.IdKardex;
                            objE_DocumentoDetalle.FlagMuestra = false;//item.FlagMuestra;
                            objE_DocumentoDetalle.FlagRegalo = false; //item.FlagRegalo;
                            objE_DocumentoDetalle.IdPromocion = null; //item.IdPromocion;
                            objE_DocumentoDetalle.Stock = 0;
                            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                            mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                        }

                        bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                        gcDocumentoDetalle.DataSource = bsListado;
                        gcDocumentoDetalle.RefreshDataSource();

                        #endregion
                    }
                }
            }
        }

        private void txtNumeroDocTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Convert.ToInt32(cboTipoDocumentoTra.EditValue) == 1)
                {
                    //buscar por dni
                    PersonaBE objE_Persona = new PersonaBE();
                    objE_Persona = new PersonaBL().SeleccionaNumeroDocumento(txtNumeroDocTra.Text.Trim());
                    txtRazonSocialTra.Text = objE_Persona.ApeNom;
                }
                else if (Convert.ToInt32(cboTipoDocumentoTra.EditValue) == 1)
                {
                    //consulta directa a la sunat
                    XtraMessageBox.Show("Ingresar los datos manualmente");
                }
                else
                {
                    //consulta a personal
                    XtraMessageBox.Show("Ingresar los datos manualmente");
                }
            }
        }

        private void SeteaMovimientoDetalle()
        {
            mListaDocumentoVentaDetalleOrigen.Clear();
            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoDetalle.DataSource = bsListado;
            gcDocumentoDetalle.RefreshDataSource();
        }

        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            frmBuscaPersona frm = new frmBuscaPersona();
            frm.TipoBusqueda = 0;
            frm.ShowDialog();
            if (frm._Be != null)
            {
                txtNumeroDocTra.Text = frm._Be.Dni;
                txtDescCliente.Text = frm._Be.ApeNom;
                txtNumeroDocTra.Properties.ReadOnly = true;
                txtDescCliente.Properties.ReadOnly = true;
            }
        }

        #endregion

        #region "Métodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboEmpresa.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la empresa.\n";
                flag = true;
            }

            if (cboTienda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la tienda.\n";
                flag = true;
            }

            if (cboDistrito.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Distrito.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el número de documento.\n";
                flag = true;
            }

            if (txtRazonSocialTra.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción del cliente.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtNumeroBultos.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingrese la cantidad de bultos.\n";
                flag = true;
            }

            if (Convert.ToInt32(txtPesoBultos.EditValue) == 0)
            {
                strMensaje = strMensaje + "- Ingrese el peso en Kilogramos - Valor entero.\n";
                flag = true;
            }

            if (txtNumeroDocTra.Text.Trim().Length < 8)
            {
                strMensaje = strMensaje + "- Ingrese el número de documento de transportista.\n";
                flag = true;
            }

            if (deFechaEnvio.Text == "")
            {
                strMensaje = strMensaje + "- Ingrese la fecha de Envío.\n";
                flag = true;
            }

            if (cboTipoDocumentoTra.EditValue.ToString() == "01")
            {
                if (txtNumeroDocumento.Text.Trim().Length != 8)
                {
                    strMensaje = strMensaje + "- El número de Dni debe tener 8 dígitos.\n";
                    flag = true;
                }
            }

            if (cboTipoDocumentoTra.EditValue.ToString() == "06")
            {
                if (txtNumeroDocumento.Text.Trim().Length != 11)
                {
                    strMensaje = strMensaje + "- El número de ruc debe tener 11 dígitos.\n";
                    flag = true;
                }

                if (txtRazonSocialTra.Text.Trim().ToString() == "")
                {
                    strMensaje = strMensaje + "- Ingrese el Nombre/Razón social del cliente.\n";
                    flag = true;
                }
            }

            if(cboMotivoTraslado.EditValue.ToString() == "04")
            {
                if(cboEmpresa.Text != txtDescCliente.Text)
                {
                    strMensaje = strMensaje + "- Para el motivo de traslado, el destinatorio debe ser igual al remitente.\n";
                    flag = true;
                }
            }

            if (cboMotivoTraslado.EditValue.ToString() != "04")
            {
                if (cboEmpresa.Text == txtDescCliente.Text)
                {
                    strMensaje = strMensaje + "- Para el motivo de traslado, el destinatorio NO debe ser igual al remitente.\n";
                    flag = true;
                }
            }

            if (txtRazonSocialTra.Text.Trim() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Nombre o Razón social del transportista.\n";
                flag = true;
            }

            if (mListaDocumentoVentaDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Ingresar la mercadería a trasladar.\n";
                flag = true;
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "DNI";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "CARNET DE EXTRAJERIA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "RUC";
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable CargarModalidad()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "01";
            dr["Descripcion"] = "TRANSPORTE PUBLICO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "02";
            dr["Descripcion"] = "TRANSPORTE PRIVADO";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarMotivoTraslado()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "01";
            dr["Descripcion"] = "VENTA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "04";
            dr["Descripcion"] = "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "14";
            dr["Descripcion"] = "VENTA SUJETA A CONFIRMACION DEL COMPRADOR";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "02";
            dr["Descripcion"] = "COMPRA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "18";
            dr["Descripcion"] = "TRASLADO EMISOR ITINERANTE CP";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = "13";
            dr["Descripcion"] = "OTROS";
            dt.Rows.Add(dr);
            return dt;
        }

        private DataTable CargarDocumentoOrigen()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "87";
            dr["Descripcion"] = "PEDIDO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "29";
            dr["Descripcion"] = "NOTA DE SALIDA";
            dt.Rows.Add(dr);
            return dt;
        }

        private void CargaDocumentoVentaDetalle()
        {
            if (IdOrigen == 0)
            {
                List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);

                foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
                {
                    CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                    objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;//item.IdDocumentoVentaDetalle;
                    objE_DocumentoDetalle.Item = item.Item;
                    objE_DocumentoDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                    objE_DocumentoDetalle.PrecioUnitario = 0;// item.PrecioUnitario;
                    objE_DocumentoDetalle.PorcentajeDescuento = 0;// item.PorcentajeDescuento;
                    objE_DocumentoDetalle.Descuento = 0; // item.Descuento;
                    objE_DocumentoDetalle.PrecioVenta = 0; //item.PrecioVenta;
                    objE_DocumentoDetalle.ValorVenta = 0; // item.ValorVenta;
                    objE_DocumentoDetalle.CodAfeIGV = "10";// item.CodAfeIGV;
                    objE_DocumentoDetalle.IdKardex = 0;// item.IdKardex;
                    objE_DocumentoDetalle.FlagMuestra = false;//item.FlagMuestra;
                    objE_DocumentoDetalle.FlagRegalo = false; //item.FlagRegalo;
                    objE_DocumentoDetalle.IdPromocion = null; //item.IdPromocion;
                    objE_DocumentoDetalle.Stock = 0;
                    objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                }

                bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                gcDocumentoDetalle.DataSource = bsListado;
                gcDocumentoDetalle.RefreshDataSource();
            }
            else if (IdOrigen == 1)
            {
                List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = null;
                lstMovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdMovimientoAlmacen);

                foreach (MovimientoAlmacenDetalleBE item in lstMovimientoAlmacenDetalle)
                {
                    CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                    objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    objE_DocumentoDetalle.IdDocumentoVenta = 0;
                    objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;//item.IdDocumentoVentaDetalle;
                    objE_DocumentoDetalle.Item = item.Item;
                    objE_DocumentoDetalle.IdProducto = item.IdProducto;
                    objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                    objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                    objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                    objE_DocumentoDetalle.Cantidad = item.Cantidad;
                    objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                    objE_DocumentoDetalle.PrecioUnitario = 0;// item.PrecioUnitario;
                    objE_DocumentoDetalle.PorcentajeDescuento = 0;// item.PorcentajeDescuento;
                    objE_DocumentoDetalle.Descuento = 0; // item.Descuento;
                    objE_DocumentoDetalle.PrecioVenta = 0; //item.PrecioVenta;
                    objE_DocumentoDetalle.ValorVenta = 0; // item.ValorVenta;
                    objE_DocumentoDetalle.CodAfeIGV = "10";// item.CodAfeIGV;
                    objE_DocumentoDetalle.IdKardex = 0;// item.IdKardex;
                    objE_DocumentoDetalle.FlagMuestra = false;//item.FlagMuestra;
                    objE_DocumentoDetalle.FlagRegalo = false; //item.FlagRegalo;
                    objE_DocumentoDetalle.IdPromocion = null; //item.IdPromocion;
                    objE_DocumentoDetalle.Stock = 0;
                    objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);
                }

                bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                gcDocumentoDetalle.DataSource = bsListado;
                gcDocumentoDetalle.RefreshDataSource();
            }
        }

        private void ImpresionElectronicaLocal_Guias(int ParIdEmpresa, int IdDocumentoVenta, int IdTipoDocumento, string Formato)
        {
            frmListaPrinters frmPrinter = new frmListaPrinters();
            if (frmPrinter.ShowDialog() == DialogResult.OK)
            {
                List<ReporteDocumentoVentaElectronicaBE> lstReporte = null;
                lstReporte = new ReporteDocumentoVentaElectronicaBL().ListadoGuia(IdDocumentoVenta);

                #region "Codigo QR"
                //int Regs = lstReporte.Count() - 1;
                //string ValorQR = lstReporte[0].Ruc + "|" + lstReporte[0].IdConTipoComprobantePago + "|" + lstReporte[0].Serie + "|" + lstReporte[0].Numero + "|" + lstReporte[0].Igv + "|" + lstReporte[0].Total + "|" + Convert.ToDateTime(lstReporte[0].Fecha.ToShortDateString()).ToString("yyyy-MM-dd") + "|" + lstReporte[0].TipoIdentidad + "|" + lstReporte[0].NumeroDocumento;

                //Gma.QrCodeNet.Encoding.QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
                //QrCode qrCode = new QrCode();
                //qrEncoder.TryEncode(ValorQR, out qrCode);

                //GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
                //MemoryStream ms = new MemoryStream();

                //renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
                //var imageTemporal = new Bitmap(ms);
                //var imagen = new Bitmap(imageTemporal, new Size(new Point(200, 200)));
                //lstReporte[Regs].CodigoQR = new FuncionBase().Image2Bytes(imagen);
                //imagen.Save("imagen.png", ImageFormat.Png);
                #endregion

                if (lstReporte.Count > 0)
                {
                    //if (Formato == "TK")//Ticket
                    //{
                    //    if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    //    {
                    //        XtraMessageBox.Show("El formato Ticket de NC no existe, por favor verificar.\nConsultar con el área de sistemas");
                    //    }
                    //    else
                    //    {
                    //        rptGuiaRemisionPanoramaElectronica objReporteGuia = new rptGuiaRemisionPanoramaElectronica();
                    //        objReporteGuia.SetDataSource(lstReporte);
                    //        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                    //    }

                    //}
                    //else //A4
                    //{
                    //if (IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    //{
                    //    rptGuiaRemisionPanoramaElectronica objReporteGuia = new rptGuiaRemisionPanoramaElectronica();
                    //    objReporteGuia.SetDataSource(lstReporte);
                    //    Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                    //}
                    //else
                    //{

                    if (ParIdEmpresa==3)  // Corona
                    {
                        rptGuiaRemisionPanoramaElectronicaRER objReporteGuia = new rptGuiaRemisionPanoramaElectronicaRER();
                        objReporteGuia.SetDataSource(lstReporte);
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                    }
                    else if (ParIdEmpresa == 8) // Amalia Huaman
                    {
                        rptGuiaRemisionPanoramaElectronicaRER objReporteGuia = new rptGuiaRemisionPanoramaElectronicaRER();
                        objReporteGuia.SetDataSource(lstReporte);
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                    }
                    else if (ParIdEmpresa == 19)  // Betabe Tapia
                    {
                        rptGuiaRemisionPanoramaElectronicaRER objReporteGuia = new rptGuiaRemisionPanoramaElectronicaRER();
                        objReporteGuia.SetDataSource(lstReporte);
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                    }
                    else if (ParIdEmpresa == 20)  /// Roxana Tapia
                    {
                        rptGuiaRemisionPanoramaElectronicaRER objReporteGuia = new rptGuiaRemisionPanoramaElectronicaRER();
                        objReporteGuia.SetDataSource(lstReporte);
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                    }
                    else if (ParIdEmpresa == 21)  //  Liliana Tapia
                    {
                        rptGuiaRemisionPanoramaElectronicaRER objReporteGuia = new rptGuiaRemisionPanoramaElectronicaRER();
                        objReporteGuia.SetDataSource(lstReporte);
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                    }
                    else if (ParIdEmpresa == 23)  /// Eleazar Tapia
                    {
                        rptGuiaRemisionPanoramaElectronicaRER objReporteGuia = new rptGuiaRemisionPanoramaElectronicaRER();
                        objReporteGuia.SetDataSource(lstReporte);
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);
                    }
                    else   // Otros Panorama
                    {
                        rptGuiaRemisionPanoramaElectronica objReporteGuia = new rptGuiaRemisionPanoramaElectronica();
                        objReporteGuia.SetDataSource(lstReporte);
                        Impresion.Imprimir(objReporteGuia, frmPrinter.strNamePrinter, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize); 
                    } 
                }
            }
        }

        #endregion

        public class CDocumentoVentaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdDocumentoVenta { get; set; }
            public Int32 IdDocumentoVentaDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Int32 CantidadAnt { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public String CodAfeIGV { get; set; }
            public Int32 IdAlmacen { get; set; }
            public Int32? IdKardex { get; set; }
            public Int32? IdPromocion { get; set; }
            public String DescPromocion { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32 Stock { get; set; }
            public Int32 TipoOper { get; set; }

            public CDocumentoVentaDetalle()
            {

            }
        }

        private void cboMotivoTraslado_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboVehiculo_EditValueChanged(object sender, EventArgs e)
        {
            if (cboVehiculo.EditValue != null)
            { 
                VehiculoBE objE_Vehiculo = null;
            objE_Vehiculo = new VehiculoBL().SeleccionaMarca(Convert.ToInt32(cboVehiculo.EditValue));

            txtMarca.EditValue = objE_Vehiculo.Marca;
        }
            //{
            //    BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
            //    cboProvincia.EditValue = Parametros.sIdProvincia;
            //}
        }
    }
}