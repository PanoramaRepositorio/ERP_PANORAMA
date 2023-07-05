using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PagoServicioDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPagoServicioDetalle { get; set; }
		[DataMember]
		public Int32 IdPagoServicio { get; set; }
		[DataMember]
		public Int32 NumeroCuota { get; set; }
		[DataMember]
		public DateTime? FechaPago { get; set; }
		[DataMember]
		public DateTime? FechaVencimiento { get; set; }
		[DataMember]
		public Decimal Importe { get; set; }
		[DataMember]
		public String TipoMovimiento { get; set; }
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

