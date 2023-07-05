using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MotivoAusenciaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdMotivoAusencia { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescMotivoAusencia { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        #endregion
    }
}
