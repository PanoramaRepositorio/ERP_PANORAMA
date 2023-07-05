using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteSeparacionDetalleBE
    {
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime FechaSeparacion { get; set; }
        [DataMember]
        public DateTime FechaPago { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public Decimal CreditoCargo { get; set; }
        [DataMember]
        public Decimal PagoAbono { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }
    }
}
