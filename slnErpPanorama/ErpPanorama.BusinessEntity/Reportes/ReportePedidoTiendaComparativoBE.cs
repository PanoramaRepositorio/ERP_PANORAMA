using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public  class ReportePedidoTiendaComparativoBE
    {

        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
    }
}
