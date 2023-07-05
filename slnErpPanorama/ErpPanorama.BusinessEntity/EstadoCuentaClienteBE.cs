using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class EstadoCuentaClienteBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdEstadoCuentaCliente { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 Periodo { get; set; }
		[DataMember]
		public Int32 IdCliente { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
		public String NumeroDocumento { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public String Concepto { get; set; }
		[DataMember]
		public DateTime? FechaVencimiento { get; set; }
        [DataMember]
        public Int32 DiasVencimiento { get; set; }
        [DataMember]
		public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
		public Decimal Importe { get; set; }
		[DataMember]
		public String TipoMovimiento { get; set; }
		[DataMember]
		public Int32 IdMotivo { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
		public Int32? IdDocumentoVenta { get; set; }
		[DataMember]
		public Int32? IdPedido { get; set; }
		[DataMember]
		public Int32? IdMovimientoCaja { get; set; }
		[DataMember]
		public Int32? IdCuentaBancoDetalle { get; set; }
        [DataMember]
        public Int32? IdPersona { get; set; }
        [DataMember]
        public String DescPersona { get; set; }
        [DataMember]
        public String PersonaAprueba { get; set; }
        [DataMember]
		public String UsuarioRegistro { get; set; }
		[DataMember]
		public DateTime FechaRegistro { get; set; }
		[DataMember]
		public String Observacion { get; set; }
		[DataMember]
		public Decimal Saldo { get; set; }
        [DataMember]
        public String GrupoPago { get; set; }
        [DataMember]
        public Int32 IdEstadoCuentaClientePago { get; set; }
        [DataMember]
		public Boolean FlagEstado { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
		
		#endregion

	}
}

