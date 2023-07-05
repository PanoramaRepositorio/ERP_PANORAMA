﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SubLineaProductoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSubLineaProducto { get; set; }
        [DataMember]
        public Int32 IdLineaProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        #endregion
    }
}
