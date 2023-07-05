using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class DescuentoClienteMayoristaBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdDescuentoClienteMayorista { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public Int32 IdLineaProducto { get; set; }
        [DataMember]
        public Decimal MontoMin { get; set; }
        [DataMember]
        public Decimal MontoMax { get; set; }
        [DataMember]
        public Decimal PorDescuento { get; set; }
        [DataMember]
        public Boolean FlagPreVenta { get; set; }
        [DataMember]
        public Boolean FlagVenta { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }

        #endregion
    }
}
