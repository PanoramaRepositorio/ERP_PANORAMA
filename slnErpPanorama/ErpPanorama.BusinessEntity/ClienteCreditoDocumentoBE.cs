using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ClienteCreditoDocumentoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClienteCreditoDocumento { get; set; }
        [DataMember]
        public Int32 IdClienteCredito { get; set; }
        [DataMember]
        public String Documento { get; set; }
        [DataMember]
        public Boolean FlagAprobado { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}

