using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class DocumentoVentaBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdDocumentoVenta { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32? IdPedido { get; set; }
        [DataMember]
        public Int32? IdPedidoWeb { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32? IdDocumentoReferencia { get; set; }
        [DataMember]
        public Int32? IdTipoDocumentoReferencia { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        //[DataMember]
        //public DateTime FechaReferencia { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String IdTipoIdentidad { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String IdUbigeoDom { get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal TipoCambioPedido { get; set; }
        [DataMember]
        public Decimal TipoCambioSunat { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String DniVendedor { get; set; }

        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal Descuentos { get; set; }
        [DataMember]
        public Decimal PorcentajeImpuesto { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal Icbper { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
        [DataMember]
        public Decimal TotalBruto { get; set; }
        [DataMember]
        public Decimal OperacionGratuita { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Decimal TotalDetalle { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Tienda { get; set; }
        [DataMember]
        public String Canal { get; set; }
        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DireccionEmpresa { get; set; }
        [DataMember]
        public Int32? IdTipoDocumentoPedido { get; set; }
        [DataMember]
        public String CodDocumentoPedido { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String IdConTipoComprobantePago { get; set; }
        [DataMember]
        public String DescMotivoAnula { get; set; }

        [DataMember]
        public DateTime? FechaReferencia { get; set; }

        [DataMember]
        public DateTime  FechaReferencia2 { get; set; }

        [DataMember]
        public String CodTipoDocumentoReferencia { get; set; }
        [DataMember]
        public String IdConTipoComprobantePagoRef { get; set; }
        
        [DataMember]
        public String SerieReferencia { get; set; }
        [DataMember]
        public String NumeroReferencia { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32? IdSituacionPedido { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public Int32 IdClasificacionCliente { get; set; }
        [DataMember]
        public String DescClasificacionCliente { get; set; }
        [DataMember]
        public Int32 IdTipoDocumentoCliente { get; set; }
        [DataMember]
        public Int32 IdCambio { get; set; }
        [DataMember]
        public String Documento { get; set; }
        [DataMember]
        public String NumeroDevolucion { get; set; }
        [DataMember]
        public Decimal TotalVentaDolares { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }

        [DataMember]
        public Decimal Enero { get; set; }
        [DataMember]
        public Decimal Febrero { get; set; }
        [DataMember]
        public Decimal Marzo { get; set; }
        [DataMember]
        public Decimal Abril { get; set; }
        [DataMember]
        public Decimal Mayo { get; set; }
        [DataMember]
        public Decimal Junio { get; set; }
        [DataMember]
        public Decimal Julio { get; set; }
        [DataMember]
        public Decimal Agosto { get; set; }
        [DataMember]
        public Decimal Setiembre { get; set; }
        [DataMember]
        public Decimal Octubre { get; set; }
        [DataMember]
        public Decimal Noviembre { get; set; }
        [DataMember]
        public Decimal Diciembre { get; set; }

        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Boolean FlagMuestra { get; set; }


        [DataMember]
        public Decimal Tope { get; set; }
        [DataMember]
        public Decimal TopeDiario { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public Int32 IdUsuario { get; set; }
        [DataMember]
        public Int32 IdPersonaRegistro { get; set; }
        [DataMember]
        public Int32 IdPromocionProxima { get; set; }
        [DataMember]
        public Boolean FlagPromocionProxima { get; set; }

        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }

        //[DataMember]
        //public Int32 TipoIdentidad { get; set; }
        [DataMember]
        public String Codmot { get; set; }
        [DataMember]
        public String Tidomd { get; set; }
        [DataMember]
        public String Nudomd { get; set; }
        [DataMember]
        public String Fedomd { get; set; }

        [DataMember]
        public Int32 IdSituacionPSE { get; set; }
        [DataMember]
        public String DescSituacionPSE { get; set; }
        [DataMember]
        public String MensajeOSE { get; set; }
        [DataMember]
        public String CodigoNC { get; set; }
        [DataMember]
        public String UserCreate { get; set; }
        [DataMember]
        public Int32 IdSituacionContable { get; set; }
        [DataMember]
        public String DescSituacionContable { get; set; }
        [DataMember]
        public DateTime? FechaContable { get; set; }
        [DataMember]
        public Decimal TotalDiferencia { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdGrupoBaja { get; set; }
        [DataMember]
        public String GrupoBaja { get; set; }
        [DataMember]
        public String MotivoBaja { get; set; }


        [DataMember]
        public String IdUbigeoOrigen { get; set; }
        [DataMember]
        public DateTime? FechaTraslado { get; set; }
        [DataMember]
        public String MotivoTraslado { get; set; }
        [DataMember]
        public String DescTraslado { get; set; }
        [DataMember]
        public String ModalidadTraslado { get; set; }        
        [DataMember]
        public String DescModalidadTraslado { get; set; }
        [DataMember]
        public Int32 NumeroBultos { get; set; }
        [DataMember]
        public Decimal PesoBultos { get; set; }
        [DataMember]
        public String IdTipoIdentidadTra { get; set; }
        [DataMember]
        public String NumeroDocTra { get; set; }
        [DataMember]
        public String RazonSocialTra { get; set; }
        [DataMember]
        public String NumeroPlaca { get; set; }

        [DataMember]
        public String Marca { get; set; }

        [DataMember]
        public int IdComercioAmigo { get; set; }
        [DataMember]
        public string ComercioAmigo { get; set; }


        [DataMember]
        public Int32 IdDocumentoVentaDetalle { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public String CodAfeIGV { get; set; }
        [DataMember]
        public Int32? IdKardex { get; set; }
        [DataMember]
        public Boolean FlagRegalo { get; set; }

        [DataMember]
        public Boolean FlagCumpleanios { get; set; }
        [DataMember]
        public Decimal TotalDscCumpleanios { get; set; }

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public Int32 IdTiendaDestinoGuia { get; set; }

        [DataMember]
        public String LicenciaConducir { get; set; }

        [DataMember]
        public String NumeroTicket { get; set; }

        #endregion
    }
}