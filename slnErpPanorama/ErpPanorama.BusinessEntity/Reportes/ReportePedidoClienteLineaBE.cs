using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoClienteLineaBE
    {
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public int IdLineaProducto { get; set; }
        [DataMember]
        public int IdPeriodo { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set;}

//modelo
        [DataMember]
        public int IdModeloProducto { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public Decimal TotalSolesM { get; set; }

    }
}
