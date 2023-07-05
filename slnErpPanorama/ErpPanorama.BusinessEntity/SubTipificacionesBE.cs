using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SubTipificacionesBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTipificacion { get; set; }
        [DataMember]
        public String CodTipificacion { get; set; }
        [DataMember]
        public String DescTipificacion { get; set; }
        [DataMember]
        public Int32 IdSubTipificacion { get; set; }
        [DataMember]
        public String DescSubTipificacion { get; set; }
        [DataMember]
        public String DescTipoGestion { get; set; }

        [DataMember]
        public Int32 IdArea { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        #endregion

    }
}
