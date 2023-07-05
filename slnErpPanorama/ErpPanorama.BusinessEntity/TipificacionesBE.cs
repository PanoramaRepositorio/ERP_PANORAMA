using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TipificacionesBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTipificacion { get; set; }
        [DataMember]
        public String CodTipificacion { get; set; }
        [DataMember]
        public String DescTipificacion { get; set; }
        [DataMember]
        public Int32 IdTabla { get; set; }
        [DataMember]
        public Int32 IdTablaElemento { get; set; }
        [DataMember]
        public String DescTablaElemento { get; set; }
        [DataMember]
        public String DescTipoGestion { get; set; }
        #endregion

    }
}
