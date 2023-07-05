using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class FacturaCompraInsumoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdFacturaCompraInsumo { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
		public String NumeroDocumento { get; set; }
		[DataMember]
		public Int32 IdProveedor { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
		[DataMember]
		public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
		public DateTime FechaCompra { get; set; }
		[DataMember]
		public DateTime? FechaRecepcion { get; set; }
		[DataMember]
		public String TipoRegistro { get; set; }
		[DataMember]
		public Decimal Importe { get; set; }
		[DataMember]
		public Int32 IdMoneda { get; set; }
        [DataMember]
        public String Moneda { get; set; }
        [DataMember]
		public Decimal TipoCambio { get; set; }
		[DataMember]
		public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 DiasCredito { get; set; }
        [DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public Boolean FlagRecibido { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public DateTime FechaRegistro { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

