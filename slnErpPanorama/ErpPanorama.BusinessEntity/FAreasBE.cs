using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class FAreasBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public Int32 IdTablaUnidadNegocio { get; set; }
        [DataMember]
        public Int32 IdTablaElementoUnidadNegocio { get; set; }
        [DataMember]
        public String DescUnidadNegocio { get; set; }
        [DataMember]
        public Int32 IdTablaCentroCosto { get; set; }
        [DataMember]
        public Int32 IdTablaElementoCentroCosto { get; set; }
        [DataMember]
        public String DescCentroCosto { get; set; }
        [DataMember]
        public Int32 FlagEstado { get; set; }
        #endregion

    }
}
