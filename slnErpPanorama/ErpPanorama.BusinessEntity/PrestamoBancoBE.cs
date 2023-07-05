using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
	[DataContract]
	public class PrestamoBancoBE
	{
		#region "Atributos"
		[DataMember]
		public Int32 IdPrestamoBanco { get; set; }
		[DataMember]
		public Int32 IdEmpresa { get; set; }
		[DataMember]
		public Int32 IdCuentaBanco { get; set; }
        [DataMember]
        public String NumeroCuenta { get; set; }

        [DataMember]
        public Int32 IdBanco { get; set; }
        [DataMember]
        public String DescBanco { get; set; }
        [DataMember]
		public String NumeroPrestamo { get; set; }
		[DataMember]
		public String CuentaCargo { get; set; }
		[DataMember]
		public DateTime Fecha { get; set; }
		[DataMember]
		public DateTime FechaVencimiento { get; set; }
		[DataMember]
		public Decimal Prestamo { get; set; }
		[DataMember]
		public Decimal SaldoPrestamo { get; set; }
		[DataMember]
		public Decimal SaldoInteres { get; set; }
		[DataMember]
		public Decimal TotalInteres { get; set; }
        [DataMember]
        public Int32 NumeroCuotas { get; set; }

        [DataMember]
		public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public String Titular { get; set; }
        [DataMember]
		public Decimal TEA { get; set; }
		[DataMember]
		public Decimal TasaIntMoratorio { get; set; }
		[DataMember]
		public String Usuario { get; set; }
		[DataMember]
		public String Maquina { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Decimal LineaCredito { get; set; }
        [DataMember]
        public Int32 IdTipoPrestamo { get; set; }
        [DataMember]
        public String DescTipoPrestamo { get; set; }

        [DataMember]
        public Int32 NumeroCuota { get; set; }


        [DataMember]
        public Decimal SaldoPendiente { get; set; }

        [DataMember]
        public Decimal Amortizacion { get; set; }
        
        [DataMember]
        public Decimal Interes { get; set; }
        [DataMember]
        public Decimal TotalPagar { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public DateTime? FechaPago { get; set; }
        [DataMember]
        public String UsuarioPago { get; set; }
        [DataMember]
        public int Año { get; set; }
        [DataMember]
        public Decimal Enero { get; set; }
        [DataMember]
        public Decimal Febrero { get; set; }
        [DataMember]
        public Decimal Marzo { get; set; }
        [DataMember]
        public Decimal Abril { get; set; }
        [DataMember]
        public Decimal Mayo { get; set; }
        [DataMember]
        public Decimal Junio { get; set; }
        [DataMember]
        public Decimal Julio { get; set; }
        [DataMember]
        public Decimal Agosto { get; set; }
        [DataMember]
        public Decimal Setiembre { get; set; }
        [DataMember]
        public Decimal Octubre { get; set; }
        [DataMember]
        public Decimal Noviembre { get; set; }
        [DataMember]
        public Decimal Diciembre { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        #endregion

    }
}

