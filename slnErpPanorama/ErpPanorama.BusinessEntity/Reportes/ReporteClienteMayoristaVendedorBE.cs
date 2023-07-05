using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteClienteMayoristaVendedorBE
    {
        #region "Atributos"

        [DataMember]
        public String DescCliente { get; set; }
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
        public String Email { get; set; }
        [DataMember]
        public Int32 IdRuta { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public String Categoria { get; set; }

        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String Tipo { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime FechaAniv { get; set; }
        [DataMember]
        public DateTime FechaNac { get; set; }
        [DataMember]
        public DateTime FechaCompra { get; set; }
        [DataMember]
        public Decimal TotalSoles { get; set; }

        #endregion
    }
}
