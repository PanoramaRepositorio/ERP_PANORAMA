using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteComisionJefeProduccionBE
    {
        #region "Atributos"
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public Decimal Sueldo { get; set; }
        [DataMember]
        public Decimal ValorVenta005 { get; set; }
        [DataMember]
        public Decimal ValorVenta0015 { get; set; }

        #endregion
    }
}
