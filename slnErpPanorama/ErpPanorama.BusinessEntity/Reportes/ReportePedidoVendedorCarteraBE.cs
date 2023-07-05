using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePedidoVendedorCarteraBE
    {
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public String Vendedor { get; set; }
        [DataMember]
        public decimal TotalSoles { get; set; }
        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public String OtroTelefono { get; set; }
        [DataMember]
        public String TelefonoAdicional { get; set; }
        [DataMember]
        public String Email { get; set; }
    }
}
