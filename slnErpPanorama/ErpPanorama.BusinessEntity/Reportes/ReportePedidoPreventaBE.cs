using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoPreventaBE
    {
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String DescRuta { get; set; }

        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }   


    }
}
