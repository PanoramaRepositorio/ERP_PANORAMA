using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class EquipoConexionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEquipoConexion { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdEquipo { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String HostName { get; set; }
        [DataMember]
        public String Mac { get; set; }
        [DataMember]
        public String Ip { get; set; }
        [DataMember]
        public String UsuarioERP { get; set; }
        [DataMember]
        public String VersionERP { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
