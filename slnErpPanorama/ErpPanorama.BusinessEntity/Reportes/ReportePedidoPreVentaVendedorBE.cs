using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoPreVentaVendedorBE
    {
        #region "Propiedades"

        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        
        #endregion
    }
}
