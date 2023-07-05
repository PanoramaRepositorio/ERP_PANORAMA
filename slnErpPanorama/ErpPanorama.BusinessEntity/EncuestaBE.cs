using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class EncuestaBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdEncuesta { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Boolean FlagDescuento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        #endregion
    }
}
