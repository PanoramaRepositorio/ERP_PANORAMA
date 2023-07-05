using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorBE
    {
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
    }
}
