using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ClienteAsociadoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClienteAsociado { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String AbrevDocumento { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
