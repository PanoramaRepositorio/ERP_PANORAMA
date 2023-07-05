using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProductoIncentivadoCargoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProductoIncentivadoCargo { get; set; }
        [DataMember]
        public Int32 IdProductoIncentivado { get; set; }
        [DataMember]
        public Int32 IdCargo { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
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
        #endregion
    }
}
