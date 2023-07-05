using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ConsultaHistorialBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
       [DataMember]
        public String Apellidos{ get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String Descanso { get; set; }
        [DataMember]
        public  DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime FechaCese { get; set; }
  
        #endregion
    }
}
