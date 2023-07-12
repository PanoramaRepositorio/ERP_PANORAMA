using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ComboTipoCotizacionBE
    {
        [DataMember]
        public int IdTablaElemento { get; set; }

        [DataMember]
        public int? IdTabla { get; set; }

        [DataMember]
        public string Abreviatura { get; set; }

        [DataMember]
        public string DescTablaElemento { get; set; }

        [DataMember]
        public int? IdTablaExterna { get; set; }

        [DataMember]
        public decimal? Valor { get; set; }

        [DataMember]
        public bool? FlagEstado { get; set; }
    }
}
