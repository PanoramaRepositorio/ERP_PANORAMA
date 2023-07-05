using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteEstadoCuentaClienteDetBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEstadoCuentaCliente { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Int32 DiasVencimiento { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }

        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }
        #endregion
    }
}
