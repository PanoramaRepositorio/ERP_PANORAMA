using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PisoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPiso { get; set; }
        [DataMember]
        public Int32 IdUbicacion { get; set; }
        [DataMember]
        public String DescPiso { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }
        #endregion
    }
}
