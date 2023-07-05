using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    public class ReportePedidoCreditoSituacionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        #endregion

    }
}
