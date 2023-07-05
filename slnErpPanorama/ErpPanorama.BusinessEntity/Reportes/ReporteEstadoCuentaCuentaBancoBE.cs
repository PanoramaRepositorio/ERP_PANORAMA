using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteEstadoCuentaCuentaBancoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public DateTime FechaCredito { get; set; }
        [DataMember]
        public DateTime FechaDeposito { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        #endregion
    }
}
