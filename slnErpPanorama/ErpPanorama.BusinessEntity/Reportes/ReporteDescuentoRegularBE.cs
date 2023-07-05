using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDescuentoClienteFinalBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDescuentoClienteFinal { get; set; }
        [DataMember]
        public Int32 IdCampana { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public Decimal MontoInicio { get; set; }
        [DataMember]
        public Decimal MontoFin { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescCampana { get; set; }
        [DataMember]
        public String TipoCliente { get; set; }
        [DataMember]
        public String FormaPago { get; set; }
        #endregion
    }
}


