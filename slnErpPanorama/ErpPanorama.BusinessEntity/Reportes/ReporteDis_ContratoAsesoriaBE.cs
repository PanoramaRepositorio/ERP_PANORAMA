using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDis_ContratoAsesoriaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDis_ContratoAsesoria { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Titulo { get; set; }
        [DataMember]
        public String CuerpoSustantivo { get; set; }
        [DataMember]
        public String Procedimiento { get; set; }
        [DataMember]
        public String PlazoCosto { get; set; }
        [DataMember]
        public String Publicidad { get; set; }
        [DataMember]
        public String Version { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
