using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AlmacenMotivoMovimientoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 AlmacenMotivoMovimiento { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdTablaElemento { get; set; }
        [DataMember]
        public String DescTablaElemento { get; set; }
        
        #endregion
    }
}
