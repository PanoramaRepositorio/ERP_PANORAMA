using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoDolaresBE
    {
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCampana { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String AbrevDomicilio { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String NumeroDocumentoAsociado { get; set; }
        [DataMember]
        public String DescClienteAsociado { get; set; }
        [DataMember]
        public String DireccionAsociado { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public String Observacion { get; set; }
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
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Decimal TotalBruto { get; set; }
        [DataMember]
        public Boolean FlagPreVenta { get; set; }
        [DataMember]
        public Decimal PrecioUnitarioSoles { get; set; }
        [DataMember]
        public Decimal PrecioVentaSoles { get; set; }
        [DataMember]
        public Decimal ValorVentaSoles { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
        [DataMember]
        public byte[] CodigoBarraNumero { get; set; }

    }
}
