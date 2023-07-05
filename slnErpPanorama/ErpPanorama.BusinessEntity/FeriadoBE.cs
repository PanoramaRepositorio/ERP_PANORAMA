using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class FeriadoBE
	{
        #region "Atributos"
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public Int32 IdFeriado { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 Mes { get; set; }
        [DataMember]
        public String DescMes { get; set; }
        [DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public String DescFeriado { get; set; }
		[DataMember]
		public Boolean FlagEstado { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

