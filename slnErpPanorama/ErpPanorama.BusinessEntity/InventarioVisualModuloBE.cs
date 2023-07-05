using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class InventarioVisualModuloBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInventarioVisualModulo { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdInventarioVisualBloque { get; set; }
        [DataMember]
        public String DesTienda { get; set; }
        [DataMember]
        public String DescModulo { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
