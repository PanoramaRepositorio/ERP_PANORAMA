using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class MovimientoCajaChicaBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdMovimientoCajaChica { get; set; }
		[DataMember]
		public Int32 IdCajaChica { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 IdTipoAnexo { get; set; }
        [DataMember]
        public Int32 IdAnexo { get; set; }
        [DataMember]
        public String DescAnexo { get; set; }
        [DataMember]
		public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
		public String NumeroDocumento { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public String Concepto { get; set; }

        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }

        [DataMember]
		public Int32 IdCondicionPago { get; set; }
        [DataMember]
        public String DescCondicionPago { get; set; }
        [DataMember]
		public Decimal Importe { get; set; }
		[DataMember]
		public String TipoMovimiento { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public Int32 IdPersonaAutoriza { get; set; }
        [DataMember]
        public String DescPersonaAutoriza { get; set; }
        [DataMember]
        public Int32 IdOrigen { get; set; }
        [DataMember]
        public String DescOrigen { get; set; }
        [DataMember]
		public String UsuarioRegistro { get; set; }
		[DataMember]
		public DateTime FechaRegistro { get; set; }
		[DataMember]
		public String UsuarioModifica { get; set; }
		[DataMember]
		public DateTime FechaModifica { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

