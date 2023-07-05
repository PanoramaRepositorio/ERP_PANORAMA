using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class DescuentoClienteFinalBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDescuentoClienteFinal { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdClasificacionCliente { get; set; }
        [DataMember]
        public Int32 CantidadMinima { get; set; }
        [DataMember]
        public Int32 CantidadMaxima { get; set; }
        [DataMember]
        public Int32 IdTipoPrecio { get; set; }
        [DataMember]
        public Int32 PorDescuento { get; set; }
        [DataMember]
        public Boolean FlagOpcional { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescTipoPrecio { get; set; }
        [DataMember]
        public String DescClasificacionCliente { get; set; }

        #endregion
    }
}
