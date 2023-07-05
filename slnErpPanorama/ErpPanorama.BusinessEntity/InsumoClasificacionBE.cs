using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class InsumoClasificacionBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdInsumoClasificacion { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public String DescInsumoClasificacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

