using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CajaValorFijoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCajaValorFijo { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String TipoValor { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal Denominacion { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
