using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PromocionMarcaBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPromocionMarca { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdMarca { get; set; }
		[DataMember]
		public Decimal MontoMin { get; set; }
		[DataMember]
		public Decimal MontoMax { get; set; }
		[DataMember]
		public Decimal Vale { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

