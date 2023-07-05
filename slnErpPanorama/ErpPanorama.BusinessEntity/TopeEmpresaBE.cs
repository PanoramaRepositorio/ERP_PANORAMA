using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TopeEmpresaBE
    {
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Decimal Tope { get; set; }
        [DataMember]
        public Decimal TopeDiario { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }
    }
}
