using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class LineaProductoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdLineaProducto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Numero { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdFamiliaProducto { get; set; }
        [DataMember]
        public String DescFamiliaProducto { get; set; }

        #endregion
    }
}