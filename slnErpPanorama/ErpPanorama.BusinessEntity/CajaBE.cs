using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CajaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public String Mac { get; set; }
        [DataMember]
        public Boolean FlagVenta { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }

        #endregion
    }
}
