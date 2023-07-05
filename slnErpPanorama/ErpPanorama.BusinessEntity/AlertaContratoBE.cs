using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AlertaContratoBE
    {
        #region "Atributos"
  
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public DateTime FechaVen { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescCargo { get; set; }


        #endregion
    }
}
