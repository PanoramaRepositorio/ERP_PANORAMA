using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDevolucionesMayoristasRutaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCambio { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String NumeroDocumentoVenta { get; set; }
        [DataMember]
        public DateTime FechaVenta { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String NumeroDevolucion { get; set; }
        [DataMember]
        public DateTime FechaDevolucion { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescRuta { get; set; }

        #endregion
    }
}
