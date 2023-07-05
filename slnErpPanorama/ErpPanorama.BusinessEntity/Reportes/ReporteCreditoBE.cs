using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCreditoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public String NumeroPago { get; set; }
        [DataMember]
        public String AbrevFormaPago { get; set; }
        [DataMember]
        public DateTime FechaCredito { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Int32 NumeroDias { get; set; }
        [DataMember]
        public Decimal CreditoCargo { get; set; }
        [DataMember]
        public Decimal PagoAbono { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        #endregion
    }
}
