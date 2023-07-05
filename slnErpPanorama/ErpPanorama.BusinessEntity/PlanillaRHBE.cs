using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PlanillaRHBE
    {
        #region "Atributos"


        [DataMember]
        public String NombresyApellidos { get; set; }
        [DataMember]
        public String FechaIngreso { get; set; }
        [DataMember]
        public Double Sueldo { get; set; }
        [DataMember]
        public int Dias { get; set; }
        [DataMember]
        public Double HorasExtras { get; set; }
        [DataMember]
        public Double SBruto { get; set; }
        #endregion
    }
}
