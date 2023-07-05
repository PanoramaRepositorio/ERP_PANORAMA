using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCumpleaniosBE
    {
        #region "Atributos"
      
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public DateTime FechaNac { get; set; }
        
        #endregion
    }
}
