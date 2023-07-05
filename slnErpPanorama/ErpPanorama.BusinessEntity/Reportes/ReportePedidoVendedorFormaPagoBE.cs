using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorFormaPagoBE
    {
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String TipoVendedor { get; set; }
        [DataMember]
        public String TipoVenta { get; set; }
        [DataMember]
        public String TipoCliente { get; set; }
        
        [DataMember]
        public decimal Contado { get; set; }
        [DataMember]
        public decimal Credito { get; set; }
        [DataMember]
        public decimal Obsequio { get; set; }
        [DataMember]
        public decimal Consignacion { get; set; }
        [DataMember]
        public decimal Devolucion { get; set; }
        [DataMember]
        public decimal Asaf { get; set; }
        [DataMember]
        public decimal Separacion { get; set; }
        [DataMember]
        public decimal Contraentrega { get; set; }
        [DataMember]
        public decimal Copagan { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        
    }
}
