using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AsistenciaBE
    {
        #region "Atributos"

        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string ApeNom { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime? FechaIngreso { get; set; }
        [DataMember]
        public DateTime? FechaSalida { get; set; }

        #endregion
    }
}
