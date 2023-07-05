using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteClienteListaGeneralBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
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
        public String EmailAdicional { get; set; }

        #endregion
    }
}
