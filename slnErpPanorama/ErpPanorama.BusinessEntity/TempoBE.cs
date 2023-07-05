using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TempoBE
    {
        #region "Atributos"

        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public String FechaDesde { get; set; }
        [DataMember]
        public String FechaHasta { get; set; }
        [DataMember]
        public String TiempoTrabajado { get; set; }


        #endregion
    }
}
