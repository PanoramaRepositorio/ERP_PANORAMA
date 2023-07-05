using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class VehiculoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdVehiculo { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
		public String Placa { get; set; }
		[DataMember]
		public String NumeroSerie { get; set; }
		[DataMember]
		public String NumeroMotor { get; set; }
		[DataMember]
		public String Color { get; set; }
		[DataMember]
		public String Marca { get; set; }
		[DataMember]
		public String Modelo { get; set; }
		[DataMember]
		public String Codigo { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32? IdConductor { get; set; }
        [DataMember]
        public String DescConductor { get; set; }
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

