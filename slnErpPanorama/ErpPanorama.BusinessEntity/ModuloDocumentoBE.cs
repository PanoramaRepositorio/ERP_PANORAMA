using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ModuloDocumentoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdModuloDocumento { get; set; }
        [DataMember]
        public Int32 IdModulo { get; set; }
        [DataMember]
        public String DescModulo { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }


        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        #endregion
    }
}

