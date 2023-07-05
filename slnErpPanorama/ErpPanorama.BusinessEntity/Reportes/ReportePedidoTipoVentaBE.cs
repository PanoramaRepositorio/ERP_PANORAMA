using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoTipoVentaBE
    {
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public decimal Meta { get; set; }
        [DataMember]
        public decimal AlcanceMeta { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public DateTime FechaPedido { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public decimal TotalSoles { get; set; }
        [DataMember]
        public DateTime FechaFacturacion { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String DescAsesor { get; set; }
        [DataMember]
        public String Tienda { get; set; }

        [DataMember]
        public decimal TotalVentas { get; set; }
        [DataMember]
        public Int32 Tickets { get; set; }
        [DataMember]
        public String Situacion { get; set; }


    }
}
