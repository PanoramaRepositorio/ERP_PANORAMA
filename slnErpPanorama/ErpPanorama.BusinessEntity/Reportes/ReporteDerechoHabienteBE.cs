using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDerechoHabienteBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdDerechoHabiente { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdSexo { get; set; }
        [DataMember]
        public String DescSexo { get; set; }
        [DataMember]
        public Int32 IdParentesco { get; set; }
        [DataMember]
        public String DescParentesco { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public DateTime FechaNac { get; set; }
        [DataMember]
        public String Ocupacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        

        #endregion
    }
}
