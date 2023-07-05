using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ChequeBancoBE
    {
        #region "Atributos"

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
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DesMoneda { get; set; }
        [DataMember]
        public Decimal TCambio { get; set; }
        [DataMember]
        public String NumeroCheque { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
