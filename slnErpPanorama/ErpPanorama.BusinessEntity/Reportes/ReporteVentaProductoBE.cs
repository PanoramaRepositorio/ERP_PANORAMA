using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    //[DataContract]
    public class ReporteVentaProductoBE
    {
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
        [DataMember]
        public Int32 CantidadComprada { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public Int32 Stock { get; set; }
        [DataMember]
        public Int32 StockPedido { get; set; }
        [DataMember]
        public Int32 StockNotaSalida { get; set; }
        [DataMember]
        public DateTime FechaCompra { get; set; }
        [DataMember]
        public DateTime FechaRecepcion { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }


        [DataMember]
        public Decimal Ratio { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }
        [DataMember]
        public Int32 DiasVendidos { get; set; }
        [DataMember]
        public Decimal DescuentoSugerido { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public String Mes { get; set; }

        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public String NumeroFactura { get; set; }

        [DataMember]
        public Decimal TotalCostoSoles { get; set; }
        [DataMember]
        public Decimal UtilidadBruta { get; set; }
        [DataMember]
        public Decimal MargenBruto { get; set; }
        [DataMember]
        public DateTime FechaVenta { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }
        [DataMember]
        public String Nacionalidad { get; set; }


    }
}
