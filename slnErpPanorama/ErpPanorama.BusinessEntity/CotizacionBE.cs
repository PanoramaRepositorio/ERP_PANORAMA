using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class CotizacionBE
    {
        #region "Atributos"
		[DataMember]
		public Int32 IdCotizacion { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 IdPedido { get; set; }
		[DataMember]
		public Int32 IdCliente { get; set; }
		[DataMember]
		public String NumeroCotizacion { get; set; }
		[DataMember]
		public Int32 IdMoneda { get; set; }
		[DataMember]
		public Decimal TipoCambio { get; set; }
		[DataMember]
		public Decimal Total { get; set; }
        [DataMember]
        public Int32 IdMotivo{ get; set; }
		[DataMember]
		public String Descripcion { get; set; }
		[DataMember]
		public DateTime FechaCredito { get; set; }
		[DataMember]
		public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }

        #endregion
    }
}

