using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCentroCostoPorAreaBE
    {
        #region "Atributos"
        [DataMember]
        public String CodGrupo { get; set; }
        [DataMember]
        public String DescGrupo { get; set; }
        [DataMember]
        public String CodCentroCosto { get; set; }
        [DataMember]
        public String DescCentroCosto { get; set; }
        [DataMember]
        public String CodCuenta { get; set; }
        [DataMember]
        public String DescCuenta { get; set; }
        [DataMember]
        public Decimal DebeUS { get; set; }
        [DataMember]
        public Decimal HaberUS { get; set; }
        [DataMember]
        public Decimal DebeMN { get; set; }
        [DataMember]
        public Decimal HaberMN { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String NombreMes { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }

        #endregion
    }
}
