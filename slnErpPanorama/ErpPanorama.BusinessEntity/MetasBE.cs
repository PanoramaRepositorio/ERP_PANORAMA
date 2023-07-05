using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MetasBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdMeta { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String NombreMes { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Decimal ImporteFinal { get; set; }
        [DataMember]
        public Decimal ImporteMayorista { get; set; }
        [DataMember]
        public Decimal ImporteDiseno { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String Cargo { get; set; }

        #endregion
    }
}
