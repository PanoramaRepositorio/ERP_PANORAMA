using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class UsuarioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdUser { get; set; }
        [DataMember]
        public Int32 IdPerfil { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public Boolean FlagMaster { get; set; }
        [DataMember]
        public Boolean FlagAutorizaEliminaDocumentoVenta { get; set; }
        [DataMember]
        public String DB { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String UsuarioCrea { get; set; }
        [DataMember]
        public String DescPerfil { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32  IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        #endregion
    }
}
