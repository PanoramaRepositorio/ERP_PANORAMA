using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class CuentaBancoDetalleCausalBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdCuentaBancoDetalleCausal { get; set; }
		[DataMember]
		public String TipoMovimiento { get; set; }
		[DataMember]
		public String Descripcion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

