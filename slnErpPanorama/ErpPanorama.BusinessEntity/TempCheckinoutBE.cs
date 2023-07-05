using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class TempCheckinoutBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdTempCheckinout { get; set; }
		[DataMember]
		public Int32 IdCheckinout { get; set; }
		[DataMember]
		public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public DateTime FechaOriginal { get; set; }
		[DataMember]
		public DateTime FechaUpdate { get; set; }
		[DataMember]
		public DateTime FechaRegistro { get; set; }
		[DataMember]
		public String UsuarioRegistro { get; set; }
		[DataMember]
		public String MaquinaRegistro { get; set; }
		[DataMember]
		public Boolean FlagEstado { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        #endregion

    }
}

