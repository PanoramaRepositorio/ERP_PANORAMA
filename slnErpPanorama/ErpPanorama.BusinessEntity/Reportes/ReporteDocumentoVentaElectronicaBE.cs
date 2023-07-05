using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDocumentoVentaElectronicaBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DireccionEmpresa { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String TipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String IdConTipoComprobantePago { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String Hora { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public String IdTipoIdentidad { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String DireccionTienda { get; set; }

        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal PorcentajeImpuesto { get; set; }
        [DataMember]
        public Decimal TotalDescuento { get; set; }
        [DataMember]
        public Decimal TotalDescuentoIncIGV { get; set; }
        [DataMember]
        public Decimal OperacionGratuita { get; set; }
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal Icbper { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Decimal TotalBruto { get; set; }

        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }

        
        [DataMember]
        public String CodAfeIGV { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }


        [DataMember]
        public Decimal PagoEfectivo { get; set; }
        [DataMember]
        public Decimal PagoTarjeta { get; set; }
        [DataMember]
        public Decimal PagoNotaCredito { get; set; }

        [DataMember]
        public String CodigoNC { get; set; }
        [DataMember]
        public String DescCodigoNC { get; set; }

        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal TipoCambioSunat { get; set; }
        [DataMember]
        public String Autorizacion { get; set; }
        [DataMember]
        public byte[] CodigoQR { get; set; }



        [DataMember]
        public String IdConTipoComprobantePagoRef { get; set; }
        [DataMember]
        public String TipoDocumentoRef { get; set; }
        [DataMember]
        public String SerieReferencia { get; set; }
        [DataMember]
        public String NumeroReferencia { get; set; }
        [DataMember]
        public String FechaReferencia { get; set; }


        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String IdUbigeoOrigen { get; set; }
        [DataMember]
        public DateTime FechaTraslado { get; set; }
        [DataMember]
        public String MotivoTraslado { get; set; }
        [DataMember]
        public String ModalildadTraslado { get; set; }
        [DataMember]
        public Int32 NumeroBultos { get; set; }
        [DataMember]
        public Int32 PesoBultos { get; set; }
        [DataMember]
        public String IdTipoIdentidadTra { get; set; }
        [DataMember]
        public String NumeroDocTra { get; set; }
        [DataMember]
        public String RazonSocialTra { get; set; }
        [DataMember]
        public String NumeroPlaca { get; set; }
        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public Decimal TotalDscCumpleanios { get; set; }
        [DataMember]
        public Boolean FlagCumpleanios { get; set; }
        [DataMember]
        public String DescPromocion { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String UsuarioAprobo { get; set; }
        #endregion
    }
}
