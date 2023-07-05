using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteProductividadOperadorResumenBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Tipo { get; set; }
        [DataMember]
        public Decimal CantidadPedidoPicking { get; set; }
        [DataMember]
        public Decimal CantidadPedidoChequeo { get; set; }
        [DataMember]
        public Decimal CantidadPedidoEmbalaje { get; set; }
        [DataMember]
        public Decimal PromedioItemsPicking { get; set; }
        [DataMember]
        public Decimal PromedioItemsChequeo { get; set; }
        [DataMember]
        public Decimal PromedioItemsEmbalaje { get; set; }
        [DataMember]
        public Decimal CantidadDetallePicking { get; set; }
        [DataMember]
        public Decimal CantidadDetalleChequeo { get; set; }
        [DataMember]
        public Decimal CantidadDetalleEmbalaje { get; set; }
        [DataMember]
        public Decimal CantidadBulto { get; set; }
        [DataMember]
        public String PromedioMinutosPicking { get; set; }
        [DataMember]
        public String PromedioMinutosChequeo { get; set; }
        [DataMember]
        public String PromedioMinutosEmbalaje { get; set; }

        #endregion
    }
}
