using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class DescuentoClientePromocionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDescuentoClientePromocion { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 Items { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }

        #endregion
    }
}
