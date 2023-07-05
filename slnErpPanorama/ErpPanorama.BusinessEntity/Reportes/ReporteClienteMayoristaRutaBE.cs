using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ReporteClienteMayoristaRutaBE
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

        #endregion
    }
}
