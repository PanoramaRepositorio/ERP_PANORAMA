using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PersonaTardanzaBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPersonaTardanza { get; set; }
		[DataMember]
		public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public String Tipo { get; set; }
		[DataMember]
		public Decimal Importe { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public Boolean FlagDescuento { get; set; }
		[DataMember]
		public Int32 IdPersonaJustifica { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

