using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CuentaBancoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdCuentaBanco { get; set; }
        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String NumeroCuenta { get; set; }
        [DataMember]
        public Int32 IdTipoCuenta { get; set; }
        [DataMember]
        public String Titular { get; set; }
        [DataMember]
        public Decimal SaldoDisponible { get; set; }
        [DataMember]
        public String Oficina { get; set; }
        [DataMember]
        public String CCI { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public String DescTipoCuenta { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public DateTime? FechaUltimoRegistro { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Decimal LineaCredito { get; set; }

        // Proveedor
        [DataMember]
        public Int32 IdCuentaBancoProveedor { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }

        [DataMember]
        public Int32 TipoOper { get; set; }
        
        #endregion
    }
}
