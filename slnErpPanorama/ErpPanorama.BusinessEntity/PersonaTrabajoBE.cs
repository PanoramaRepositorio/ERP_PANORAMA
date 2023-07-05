using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PersonaTrabajoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPersonaTrabajo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public DateTime HoraInicio { get; set; }
		[DataMember]
		public DateTime HoraFin { get; set; }
		[DataMember]
		public String Observacion { get; set; }
        [DataMember]
        public String DiaSemana { get; set; }
        [DataMember]
        public String DiaFeriado { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

