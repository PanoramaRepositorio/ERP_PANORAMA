using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MetasCarteraBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdMetasCartera { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdRuta { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String NombreMes { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String DescRuta { get; set; }

        #endregion
    }
}
