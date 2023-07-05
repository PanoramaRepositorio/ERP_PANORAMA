using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCajaCajeroBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCajaVendedor { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String Nombres { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        #endregion
    }
}

