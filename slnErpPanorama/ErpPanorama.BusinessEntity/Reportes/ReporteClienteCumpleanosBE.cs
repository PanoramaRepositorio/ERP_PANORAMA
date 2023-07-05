using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteClienteCumpleanosBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public DateTime? FechaNac { get; set; }
        [DataMember]
        public DateTime? FechaAniv { get; set; }
        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public String Vendedor { get; set; }

        #endregion
    }
}
