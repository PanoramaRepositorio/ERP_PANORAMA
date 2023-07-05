using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Promocion3x2BE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPromocion3x2 { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescPromocion3x2 { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String Tipo { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public Boolean FlagContado { get; set; }
        [DataMember]
        public Boolean FlagCredito { get; set; }
        [DataMember]
        public Boolean FlagConsignacion { get; set; }
        [DataMember]
        public Boolean FlagSeparacion { get; set; }
        [DataMember]
        public Boolean FlagContraentrega { get; set; }
        [DataMember]
        public Boolean FlagCopagan { get; set; }
        [DataMember]
        public Boolean FlagObsequio { get; set; }
        [DataMember]
        public Boolean FlagAsaf { get; set; }
        [DataMember]
        public Boolean FlagClienteMayorista { get; set; }
        [DataMember]
        public Boolean FlagClienteFinal { get; set; }
        [DataMember]
        public Boolean FlagWeb { get; set; }

        #endregion
    }
}
