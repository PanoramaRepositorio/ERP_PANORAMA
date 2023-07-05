using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteStockValorizadoBE
    {
        [DataMember]
        public String Tipo { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public Decimal TotalCostoPromedio { get; set; }
        [DataMember]
        public Decimal TotalCostoUltimo { get; set; }

    }
}
