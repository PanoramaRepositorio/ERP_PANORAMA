using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PromocionProximaBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPromocionProxima { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
		public String Descripcion { get; set; }
		[DataMember]
		public DateTime FechaInicio { get; set; }
		[DataMember]
		public DateTime FechaFin { get; set; }
		[DataMember]
		public Decimal MontoMin { get; set; }
		[DataMember]
		public Decimal MontoMax { get; set; }
        [DataMember]
        public DateTime FechaDesde { get; set; }
        [DataMember]
        public DateTime FechaHasta { get; set; }
        [DataMember]
		public Decimal Descuento { get; set; }
		[DataMember]
		public String Mensaje { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        
        #endregion

    }
}

