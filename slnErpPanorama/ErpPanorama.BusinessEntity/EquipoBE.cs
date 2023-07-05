using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class EquipoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEquipo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public String HostName { get; set; }
        [DataMember]
        public String SistemaOperativo { get; set; }
        [DataMember]
        public String Mac { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public DateTime? FechaConexion { get; set; }
        

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagAcceso { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public Int32? IdEquipoConexion { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Ip { get; set; }
        [DataMember]
        public String UsuarioERP { get; set; }
        [DataMember]
        public String VersionERP { get; set; }

        [DataMember]
        public DateTime? FechaCreacion { get; set; }
        [DataMember]
        public String UsuarioCreacion { get; set; }
        [DataMember]
        public DateTime? FechaModificacion { get; set; }
        [DataMember]
        public String UsuarioModificacion { get; set; }




        #endregion

    }
}

