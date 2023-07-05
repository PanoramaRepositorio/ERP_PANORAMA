using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class VariablesBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Decimal TipoCambioMinorista { get; set; }
        [DataMember]
        public Decimal TipoCambioMayorista { get; set; }
        [DataMember]
        public Decimal TipoCambioMinoristaNacional { get; set; }
        [DataMember]
        public Decimal SueldoBaseAsesorJunior { get; set; }
        [DataMember]
        public Decimal SueldoBaseAsesorSenior { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
