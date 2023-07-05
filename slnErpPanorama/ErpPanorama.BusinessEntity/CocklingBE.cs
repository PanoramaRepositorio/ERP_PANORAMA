using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CocklingBE
    {
        #region "Atributos"
     
        [DataMember]
        public String Dni { get; set; }


        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Tipo { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Marcacion { get; set; }
        #endregion
    }
}
