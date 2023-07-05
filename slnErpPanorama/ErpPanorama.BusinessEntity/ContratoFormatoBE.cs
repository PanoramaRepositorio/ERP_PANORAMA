using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class ContratoFormatoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdContratoFormato { get; set; }
		[DataMember]
		public Int32 IdTipoContrato { get; set; }
        [DataMember]
        public String DescTipoContrato { get; set; }
        [DataMember]
		public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 RazonSocial { get; set; }
        [DataMember]
		public String Descripcion { get; set; }
		[DataMember]
		public String Titulo { get; set; }
		[DataMember]
		public String Cuerpo { get; set; }
		[DataMember]
		public String Firma { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		[DataMember]
		public DateTime? FechaCreacion { get; set; }
		[DataMember]
		public DateTime? FechaActualiza { get; set; }
		#endregion

	}
}

