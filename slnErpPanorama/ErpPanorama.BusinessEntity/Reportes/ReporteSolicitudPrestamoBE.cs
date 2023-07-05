using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteSolicitudPrestamoBE
    {
        #region "Atributos"
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime FechaSolicitud { get; set; }
        [DataMember]
        public String DescPersona { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public String DescCampana { get; set; }
        [DataMember]
        public Decimal ImportePrestamo { get; set; }
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
        public String Observacion { get; set; }
        [DataMember]
        public String Motivo { get; set; }
        [DataMember]
        public String DescPersonaAprueba { get; set; }
        [DataMember]
        public Int32 NumeroCuota { get; set; }
        [DataMember]
        public String Concepto { get; set; }
        [DataMember]
        public DateTime FechaVencimiento { get; set; }
        [DataMember]
        public Decimal Capital { get; set; }
        [DataMember]
        public Decimal Interes { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Decimal SaldoAnterior { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public String Dni { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
