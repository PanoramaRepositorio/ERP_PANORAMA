using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class TurnoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdTurno { get; set; }
		[DataMember]
		public String DescTurno { get; set; }
		[DataMember]
		public Decimal TotalHorasRef { get; set; }
		[DataMember]
		public Decimal TotalHorasTrab { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public Boolean FlagEstado { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }

		[DataMember]
		public Int32 IdEmpresa { get; set; }

		#endregion

	}
}

