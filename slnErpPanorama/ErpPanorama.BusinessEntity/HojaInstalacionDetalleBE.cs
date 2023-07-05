using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class HojaInstalacionDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdHojaInstalacionDetalle { get; set; }
		[DataMember]
		public Int32 IdHojaInstalacion { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public Int32 IdPedido { get; set; }
        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        
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
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion

    }
}

