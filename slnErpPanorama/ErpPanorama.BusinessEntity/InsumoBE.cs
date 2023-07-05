using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class InsumoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdInsumo { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
		public Int32 IdInsumoClasificacion { get; set; }
        [DataMember]
        public String DescInsumoClasificacion { get; set; }
        [DataMember]
		public String Descripcion { get; set; }
		[DataMember]
		public String CodigoBarra { get; set; }
        [DataMember]
        public Int32 Stock { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
		public byte[] Imagen { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

