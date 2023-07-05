using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class  RegIngresoEgresoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdIngresoEgreso { get; set; }
        [DataMember]
        public Int32 IdDetIngresoEgreso { get; set; }
        [DataMember]
        public Int32 IdSubTipificacion { get; set; }
        [DataMember]
        public String DescSubTipificacion { get; set; }
        [DataMember]
        public String UnidadMedida { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public Decimal Monto { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        #endregion

    }
}
