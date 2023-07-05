using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PagoServicioBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPagoServicio { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 IdTipoServicio { get; set; }
		[DataMember]
		public String Numero { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public Int32? IdProveedor { get; set; }
		[DataMember]
		public Int32? IdBanco { get; set; }
		[DataMember]
		public String Concepto { get; set; }
		[DataMember]
		public Int32 NumeroCuotas { get; set; }
		[DataMember]
		public String TipoMovimiento { get; set; }
		[DataMember]
		public Int32 IdMoneda { get; set; }
		[DataMember]
		public Decimal Importe { get; set; }
		[DataMember]
		public DateTime FechaFin { get; set; }
		[DataMember]
		public Int32 TipoRecordatorio { get; set; }
		[DataMember]
		public Int32 DiasAntes { get; set; }
		[DataMember]
		public Int32 IdSituacion { get; set; }
		[DataMember]
		public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

