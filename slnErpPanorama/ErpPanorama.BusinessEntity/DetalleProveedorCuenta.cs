using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class DetalleProveedorCuenta
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCuentaBancoProveedor { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String Cuenta { get; set; }
        [DataMember]
        public String cci { get; set; }
        [DataMember]
        public Int32 IdTipoCuenta { get; set; }
        [DataMember]
        public String DescTipoCuenta { get; set; }
        #endregion

    }
}
