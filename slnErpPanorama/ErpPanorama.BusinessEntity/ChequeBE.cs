using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ChequeBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdCheque { get; set; }
        [DataMember]
        public Int32 IdChequeBanco { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public String DesBanco { get; set; }
        [DataMember]
        public String NumeroCheque { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DesMoneda { get; set; }
        [DataMember]
        public Decimal Monto { get; set; }
        [DataMember]
        public Decimal MontoSoles { get; set; }
        [DataMember]
        public Decimal TCambio { get; set; }
        [DataMember]
        public String Portador { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public String DesMotivo { get; set; }
        [DataMember]
        public String Destino { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DesSituacion { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public DateTime FechaEmision { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String NumRecibo { get; set; }
        [DataMember]
        public String NumCajaChica { get; set; }

        #endregion
    }
}
