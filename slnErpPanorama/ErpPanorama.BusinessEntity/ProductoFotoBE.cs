using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProductoFotoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProductoFoto { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String Frontal { get; set; }
        [DataMember]
        public String Lateral { get; set; }
        [DataMember]
        public String Trasera { get; set; }
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
