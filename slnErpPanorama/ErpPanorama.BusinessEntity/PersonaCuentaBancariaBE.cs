using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PersonaCuentaBancariaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPersonaCuentaBancaria { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String NumeroCuenta { get; set; }
        [DataMember]
        public Int32 IdTipoCuenta { get; set; }
        [DataMember]
        public String DescTipoCuenta { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion

    }
}

