using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class ModuloDespachoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdModuloDespacho { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdDespachador { get; set; }
        [DataMember]
        public String DescModuloDespacho { get; set; }
        [DataMember]
		public String DescDespachador { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

