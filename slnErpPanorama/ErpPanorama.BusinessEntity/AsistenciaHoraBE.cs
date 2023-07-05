using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AsistenciaHoraBE
    {
        #region "Atributos"

        [DataMember]
        public string ApeNom { get; set; }
        [DataMember]
        public Int32 Horas { get; set; }

        #endregion
    }
}
