using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class UbigeoBE
    {
        #region "Atributos"
        [DataMember]
        public String IdDepartamento { get; set; }
        [DataMember]
        public String IdProvincia { get; set; }
        [DataMember]
        public String IdDistrito { get; set; }
        
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }

        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String DescUbigeo { get; set; }
        [DataMember]
        public Decimal TarifaEnvio { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        
        #endregion
    }
}
