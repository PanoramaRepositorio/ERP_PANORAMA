using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteEmpresaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String CodEmpresa { get; set; }
        [DataMember]
        public Int32 IdNivel { get; set; }
        [DataMember]
        public Int32 IdRegimenTributario { get; set; }
        [DataMember]
        public String Ruc { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String DescNivel { get; set; }
        [DataMember]
        public String RegimenTributario { get; set; }
        #endregion
    }
}