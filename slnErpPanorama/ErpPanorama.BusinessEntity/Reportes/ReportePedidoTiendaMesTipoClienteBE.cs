using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoTiendaMesTipoClienteBE
    {
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public Int32 Anio { get; set; }
        [DataMember]
        public String Mes { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
        public String TipoCliente { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public String DescTipoVendedor { get; set; }

        //Comparativo
        [DataMember]
        public Decimal CF { get; set; }
        [DataMember]
        public Decimal CM { get; set; }
        [DataMember]
        public Decimal CD { get; set; }
        [DataMember]
        public Decimal CE { get; set; }
        [DataMember]
        public Decimal DiferenciaCF { get; set; }
        [DataMember]
        public Decimal DiferenciaCM { get; set; }
        [DataMember]
        public Decimal DiferenciaCD { get; set; }
        [DataMember]
        public Decimal DiferenciaCE { get; set; }
        [DataMember]
        public Decimal DifValCF { get; set; }
        [DataMember]
        public Decimal DifValCM { get; set; }
        [DataMember]
        public Decimal DifValCD { get; set; }
        [DataMember]
        public Decimal DifValCE { get; set; }
        [DataMember]
        public Decimal TotalC { get; set; }
        [DataMember]
        public Decimal TotalDif { get; set; }
        [DataMember]
        public Decimal TotalDifVal { get; set; }


        [DataMember]
        public Decimal Visitas { get; set; }
        [DataMember]
        public Decimal Transaccion { get; set; }
        [DataMember]
        public Decimal Conversion { get; set; }
        [DataMember]
        public Decimal TicketPromedio { get; set; }
        [DataMember]
        public Decimal VentaTienda { get; set; }
        [DataMember]
        public Decimal TotalVisitas { get; set; }
        [DataMember]
        public Decimal TotalTransaccion { get; set; }
        [DataMember]
        public Decimal TotalConversion { get; set; }
        [DataMember]
        public Decimal TotalTicketPromedio { get; set; }


        //Meses
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

    }
}
