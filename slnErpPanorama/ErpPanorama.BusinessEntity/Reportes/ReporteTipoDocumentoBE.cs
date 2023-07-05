using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteTipoDocumentoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        #endregion
    }
}
