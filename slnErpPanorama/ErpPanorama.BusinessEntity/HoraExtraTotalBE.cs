using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class HoraExtraTotalBE
    {
        #region "Atributos"
        [DataMember]
        public String PorHorasExtras { get; set; }
        [DataMember]
        public Decimal ADDHora { get; set; }
        [DataMember]
        public Decimal ADDMin { get; set; }
        [DataMember]
        public Decimal GanaHoraExtra { get; set; }
        [DataMember]
        public Decimal GanaMinExtra { get; set; }
        #endregion
    }
}
