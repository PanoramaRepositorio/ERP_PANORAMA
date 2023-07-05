using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class HistorialBE
    {
        #region "Atributos"
        [DataMember]
        public String Id { get; set; }
        [DataMember]
        public String FechaInicio { get; set; }
        [DataMember]
        public String FechaFin { get; set; }
        #endregion
    }
}
