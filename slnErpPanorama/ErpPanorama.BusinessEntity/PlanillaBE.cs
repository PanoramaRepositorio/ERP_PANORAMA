using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PlanillaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPlanilla { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public Int32 DiasEfectivoTrabajado { get; set; }
        [DataMember]
        public Int32 HorasOrdinarias { get; set; }
        [DataMember]
        public Decimal HorasExtrasDiarias { get; set; }
        [DataMember]
        public Decimal RemuneracionVital { get; set; }
        [DataMember]
        public Decimal AportacionSeguro { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescMes { get; set; }

        #endregion
    }
}
