using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ClienteTrackingBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdClienteTracking { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String Comentario { get; set; }
        [DataMember]
        public DateTime FechaProxima { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        #endregion
    }
}
