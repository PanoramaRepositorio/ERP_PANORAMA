using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PersonaDescansoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPersonaDescanso { get; set; }
		[DataMember]
		public Int32 IdPersona { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
		public DateTime Fecha { get; set; }
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

