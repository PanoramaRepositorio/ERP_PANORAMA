using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class DescuentoClienteMayoristaFeriaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        #endregion
    }
}
