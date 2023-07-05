using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CdrBE
    {
        [DataMember]
        public String codRespuesta { get; set; }
        [DataMember]
        public String arcCdr { get; set; }
        [DataMember]
        public String indCdrGenerado { get; set; }
    }
}
