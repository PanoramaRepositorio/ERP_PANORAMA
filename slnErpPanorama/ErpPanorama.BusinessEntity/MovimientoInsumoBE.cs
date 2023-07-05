using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class MovimientoInsumoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdMovimientoInsumo { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public String Numero { get; set; }
		[DataMember]
		public Int32 IdTipoMovimiento { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public Int32 IdInsumoAlmacenOrigen { get; set; }
		[DataMember]
		public Int32 IdMotivo { get; set; }
		[DataMember]
		public Int32 IdTipoDocumento { get; set; }
		[DataMember]
		public String NumeroDocumento { get; set; }
		[DataMember]
		public String Observaciones { get; set; }
		[DataMember]
		public Int32 IdInsumoAlmacenDestino { get; set; }
		[DataMember]
		public Int32 IdMovimientoInsumoReferencia { get; set; }
		[DataMember]
		public Int32 IdSolicitudInsumo { get; set; }
		[DataMember]
		public DateTime FechaDelivery { get; set; }
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

