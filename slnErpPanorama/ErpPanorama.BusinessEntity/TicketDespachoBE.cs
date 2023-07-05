using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class TicketDespachoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdTicketDespacho { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdPedido { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public String Numero { get; set; }
		[DataMember]
		public String NumeroPedido { get; set; }
		[DataMember]
		public Int32 IdModuloDespacho { get; set; }
        [DataMember]
        public String DescModuloDespacho { get; set; }
        [DataMember]
		public Int32 IdDespachador { get; set; }
        [DataMember]
        public String DescDespachador { get; set; }
        [DataMember]
		public DateTime? FechaInicio { get; set; }
		[DataMember]
		public DateTime? FechaFin { get; set; }
		[DataMember]
		public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
		public Boolean FlagDelivery { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

