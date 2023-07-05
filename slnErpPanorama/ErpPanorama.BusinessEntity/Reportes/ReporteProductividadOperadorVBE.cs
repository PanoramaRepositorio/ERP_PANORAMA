using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteProductividadOperadorVBE
    {
        #region "Atributos"

        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public Int32 Items { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public String Tiempo { get; set; }
        [DataMember]
        public String DescPersona { get; set; }
        [DataMember]
        public String Tipo { get; set; }

        #endregion
    }
}
