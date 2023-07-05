using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ClienteCorreoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClienteCorreo { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public String Distrito { get; set; }


        #endregion
    }
}
