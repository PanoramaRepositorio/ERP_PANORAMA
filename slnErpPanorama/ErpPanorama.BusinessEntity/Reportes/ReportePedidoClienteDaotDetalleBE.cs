using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ReportePedidoClienteDaotDetalleBE
    {
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }
    }
}
