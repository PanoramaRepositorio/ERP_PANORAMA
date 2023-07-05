using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteClienteRegistroVendedorDetalleBE
    {
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String AbrevDomicilio { get; set; }
        [DataMember]
        public String Direccion { get; set; }
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
        [DataMember]
        public String TipoCliente { get; set; }
        [DataMember]
        public String FechaRegistro { get; set; }
        [DataMember]
        public String Edad { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }

    }
}
