using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class BancoProductoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdBancoProducto { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdBanco { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
		public Int32 IdTipoProducto { get; set; }
        [DataMember]
        public String DescTipoProducto { get; set; }
        [DataMember]
		public Decimal LineaCredito { get; set; }
		[DataMember]
		public Decimal MontoUtilizado { get; set; }
        [DataMember]
        public Decimal Prestamo { get; set; }
        [DataMember]
		public Decimal Disponible { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        #endregion

    }
}

