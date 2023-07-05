using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class SunatConsultaTicketBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdSunatConsultaTicket { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public String Ruc { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
		public Int32 IdGrupoBaja { get; set; }
		[DataMember]
		public String GrupoBaja { get; set; }
		[DataMember]
		public String NumeroTicket { get; set; }
		[DataMember]
		public String MensajeTicket { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
		public Boolean FlagEstado { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

