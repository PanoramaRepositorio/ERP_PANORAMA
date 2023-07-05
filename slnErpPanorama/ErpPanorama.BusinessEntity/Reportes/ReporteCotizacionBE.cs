using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteCotizacionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdCotizacion { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String NumeroCotizacion { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public DateTime FechaCredito { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
       
        #endregion
    }
}
