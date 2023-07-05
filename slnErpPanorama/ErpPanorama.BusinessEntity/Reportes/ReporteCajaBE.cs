using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCajaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
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

