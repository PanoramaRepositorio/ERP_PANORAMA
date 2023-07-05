using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PlaAfpBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPlaAfp { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescPlaAfp { get; set; }
        [DataMember]
        public Decimal AporteObligatorio { get; set; }
        [DataMember]
        public Decimal Comision { get; set; }
        [DataMember]
        public Decimal PrimaSeguro { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
