using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Dis_PiezaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDis_Pieza { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescDis_Pieza { get; set; }
        [DataMember]
        public Int32 IdTipoPieza { get; set; }
        [DataMember]
        public String DescTipoPieza { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
