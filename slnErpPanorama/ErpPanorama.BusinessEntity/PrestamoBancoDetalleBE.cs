using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PrestamoBancoDetalleBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPrestamoBancoDetalle { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
		public Int32 IdPrestamoBanco { get; set; }
		[DataMember]
		public Int32 NumeroCuota { get; set; }
		[DataMember]
		public DateTime FechaVencimiento { get; set; }
		[DataMember]
		public Decimal SaldoPendiente { get; set; }
		[DataMember]
		public Decimal Amortizacion { get; set; }
		[DataMember]
		public Decimal Interes { get; set; }
		[DataMember]
		public Decimal EnvioInformacion { get; set; }
		[DataMember]
		public Decimal Desgravamen { get; set; }
		[DataMember]
		public Decimal Seguro { get; set; }
		[DataMember]
		public Decimal TotalPagar { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public DateTime? FechaPago { get; set; }
        [DataMember]
        public String UsuarioPago { get; set; }
        #endregion

    }
}

