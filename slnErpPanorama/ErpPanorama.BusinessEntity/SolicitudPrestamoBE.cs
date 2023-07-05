using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudPrestamoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSolicitudPrestamo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String DescPersona { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Decimal Interes { get; set; }
        [DataMember]
        public Decimal TotalPago { get; set; }
        [DataMember]
        public Int32 NumeroCuotas { get; set; }
        [DataMember]
        public Int32 TipoCuota { get; set; }
        [DataMember]
        public String DescTipoCuota { get; set; }
        [DataMember]
        public Decimal Cuota { get; set; }
        [DataMember]
        public Int32 Metodo { get; set; }
        [DataMember]
        public String Motivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32? IdPersonaAprueba { get; set; }
        [DataMember]
        public String DescPersonaAprueba { get; set; }
        [DataMember]
        public Boolean FlagAprobado { get; set; }
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
        public Decimal Abono { get; set; }
        [DataMember]
        public Decimal Cargo { get; set; }
        [DataMember]
        public Decimal Saldo { get; set; }
        [DataMember]
        public String NumeroEgreso { get; set; }
        [DataMember]
        public Decimal SaldoAnterior { get; set; }

        [DataMember]
        public DateTime FechaCaja { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Int32 IdCaja { get; set; }

        [DataMember]
        public String Estado { get; set; }

        [DataMember]
        public String TipoPrestamo { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        #endregion

    }
}

