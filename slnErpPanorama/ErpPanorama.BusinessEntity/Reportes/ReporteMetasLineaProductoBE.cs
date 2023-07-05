using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteMetasLineaProductoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 Dia { get; set; }

        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Decimal ImporteMeta { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }

        #endregion
    }
}
