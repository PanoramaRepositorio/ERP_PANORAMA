using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteClienteRegistroVendedorBE
    {
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Int32 Numero { get; set; }
    }
}
