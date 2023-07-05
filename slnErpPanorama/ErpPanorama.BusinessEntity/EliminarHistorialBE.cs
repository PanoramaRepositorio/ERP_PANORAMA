using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class EliminarHistorialBE
    {
        #region "Atributos"
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String FechaInicio { get; set; }
        [DataMember]
        public String FechaFin { get; set; }
         #endregion
    }
}
