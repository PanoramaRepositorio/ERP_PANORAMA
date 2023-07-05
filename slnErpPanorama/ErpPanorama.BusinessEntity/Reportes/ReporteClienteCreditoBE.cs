using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteClienteCreditoBE
    {
        #region "Atributos"

        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String AbrevClasifica { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public DateTime FechaAprobacion { get; set; }
        [DataMember]
        public Decimal LineaCredito { get; set; }
        [DataMember]
        public Decimal LineaCreditoUtilizada { get; set; }
        [DataMember]
        public Decimal LineaCreditoDisponible { get; set; }
        [DataMember]
        public Int32 NumeroDias { get; set; }
        [DataMember]
        public Decimal Garantia { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        
        #endregion
    }
}


