using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CuentaBancoProveedorBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCuentaBancoProveedor { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String Cuenta { get; set; }
        [DataMember]
        public String cci { get; set; }
        [DataMember]
        public Int32 IdTipoCuenta { get; set; }
        [DataMember]
        public Int32 FlagEstado { get; set; }
        #endregion
    }
}
