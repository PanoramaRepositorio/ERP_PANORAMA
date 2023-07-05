using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteProductividadOperadorBE
    {
        #region "Atributos"

        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public Int32 Items { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public Int32 CantidadBulto { get; set; }
        [DataMember]
        public Int32 TotalCantidadChequeo { get; set; }
        [DataMember]
        public String TiempoPicking { get; set; }
        [DataMember]
        public String TiempoChequeo { get; set; }
        [DataMember]
        public String TiempoEmbalaje { get; set; }

        #endregion
    }
}
