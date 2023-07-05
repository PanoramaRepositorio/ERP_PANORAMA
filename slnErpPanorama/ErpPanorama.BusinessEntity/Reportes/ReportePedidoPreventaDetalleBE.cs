using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ReportePedidoPreventaDetalleBE
    {
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
    }
}
