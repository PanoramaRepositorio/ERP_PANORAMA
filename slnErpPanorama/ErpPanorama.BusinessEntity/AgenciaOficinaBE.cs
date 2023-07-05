using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AgenciaOficinaBE
    {
        [DataMember]
        public Int32 IdAgenciaOficina { get; set; }
        [DataMember]
        public Int32 IdAgencia { get; set; }
        [DataMember]
        public string DescAgencia { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string IdUbigeo { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public string NomDpto { get; set; }
        [DataMember]
        public string NomProv { get; set; }
        [DataMember]
        public string NomDist { get; set; }

    }
}
