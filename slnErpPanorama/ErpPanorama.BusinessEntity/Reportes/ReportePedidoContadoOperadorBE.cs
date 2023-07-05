using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
   [DataContract]
    public class ReportePedidoContadoOperadorBE
    {
        #region "Atributos"

        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescAuxiliar { get; set; }
        [DataMember]
        public Int32 TotalCantidadInicial { get; set; }
        [DataMember]
        public Int32 TotalItemsInicial { get; set; }
        [DataMember]
        public Int32 TotalCantidad { get; set; }
        [DataMember]
        public Int32 TotalItems { get; set; }

        #endregion
    }
}
