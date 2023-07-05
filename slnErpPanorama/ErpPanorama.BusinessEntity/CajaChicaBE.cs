using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class CajaChicaBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdCajaChica { get; set; }
		[DataMember]
		public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
		public String DescCajaChica { get; set; }
		[DataMember]
		public Int32 IdPersona { get; set; }
        [DataMember]
        public String DescPersona { get; set; }
        [DataMember]
		public Decimal SaldoSoles { get; set; }
		[DataMember]
		public Decimal SaldoDolares { get; set; }
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

