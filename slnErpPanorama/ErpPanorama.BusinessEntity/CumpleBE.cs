using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CumpleBE
    {
        #region "Atributos"
        [DataMember]
        public String dni { get; set; }  
        [DataMember]
        public String nombres { get; set; }
        [DataMember]
        public String apenom { get; set; }

        #endregion
    }
}