using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class TarjetaRegaloBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdTarjetaRegalo { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
		public Int32 IdCliente { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
		public String Numero { get; set; }
		[DataMember]
		public Decimal ImporteTotal { get; set; }
		[DataMember]
		public Decimal ImporteDisponible { get; set; }
        [DataMember]
        public Decimal ImporteUtilizado { get; set; }
        [DataMember]
		public DateTime FechaInicio { get; set; }
		[DataMember]
		public DateTime FechaFin { get; set; }
		[DataMember]
		public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
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

