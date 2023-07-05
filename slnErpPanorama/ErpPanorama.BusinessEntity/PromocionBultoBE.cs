using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PromocionBultoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPromocionBulto { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public String DescPromocionBulto { get; set; }
		[DataMember]
		public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
		[DataMember]
		public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
		[DataMember]
		public DateTime FechaInicio { get; set; }
		[DataMember]
		public DateTime FechaFin { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }


        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
		
		#endregion

	}
}

