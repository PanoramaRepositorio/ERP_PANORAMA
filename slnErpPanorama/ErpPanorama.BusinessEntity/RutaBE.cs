using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class RutaBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdRuta { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescRuta { get; set; }
        [DataMember]
        public Int32 IdVendedor { get; set; }
        [DataMember]
        public String DescVendedor{ get; set; }
        [DataMember]
        public String IdUbigeo { get; set; }
        [DataMember]
        public String Dia { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String Usuario { get; set; }

        [DataMember]
        public String NomDpto { get; set; }
        [DataMember]
        public String NomProv { get; set; }
        [DataMember]
        public String NomDist { get; set; }

        [DataMember]
        public String Tipo { get; set; }

        #endregion
    }
}
