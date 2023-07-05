using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteTicketVendedorBE
    {
        #region "Atributos"
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String Cargo { get; set; }
        [DataMember]
        public Int32 Tickets { get; set; }
        [DataMember]
        public Decimal TotalVentaAl75 { get; set; }
        [DataMember]
        public Decimal TotalVentaAl100 { get; set; }
        [DataMember]
        public Decimal TotalVentaFabrica { get; set; }
        [DataMember]
        public Decimal TotalVentaFinal { get; set; }
        [DataMember]
        public Decimal TotalVenta { get; set; }
        [DataMember]
        public Decimal TicketPromedio { get; set; }
        [DataMember]
        public Decimal Participacion { get; set; }

        #endregion
    }
}
