using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class TurnoDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdTurnoDetalle { get; set; }
		[DataMember]
		public Int32 IdTurno { get; set; }
		[DataMember]
		public Int32 DiaSemana { get; set; }
		[DataMember]
		public String DiaSemanaName { get; set; }
		[DataMember]
		public DateTime HoraIngreso { get; set; }
		[DataMember]
		public DateTime HoraSalidaRef { get; set; }
		[DataMember]
		public DateTime HoraIngresoRef { get; set; }
		[DataMember]
		public DateTime HoraSalida { get; set; }
		[DataMember]
		public Decimal HorasRef { get; set; }
		[DataMember]
		public Decimal HorasTrab { get; set; }
		[DataMember]
		public Boolean FlagEstado { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 TipoOper { get; set; }
		#endregion

	}
}

