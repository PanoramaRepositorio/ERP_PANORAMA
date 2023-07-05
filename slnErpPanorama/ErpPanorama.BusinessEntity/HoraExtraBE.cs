using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class HoraExtraBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdHoraExtra { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 Mes { get; set; }
        [DataMember]
        public DateTime FechaDesde { get; set; }
        [DataMember]
        public DateTime? FechaHasta { get; set; }
        [DataMember]
        public DateTime? Ingreso { get; set; }
        [DataMember]
        public DateTime? Salida { get; set; }
        [DataMember]
        public DateTime? IngresoNormal { get; set; }
        [DataMember]
        public DateTime? SalidaNormal { get; set; }
        [DataMember]
        public Int32 IdAutorizado { get; set; }
        [DataMember]
        public Decimal Horas25 { get; set; }
        [DataMember]
        public Decimal Horas35 { get; set; }
        [DataMember]
        public Decimal Horas100 { get; set; }
        [DataMember]
        public Decimal HorasComp { get; set; }
        [DataMember]
        public Decimal Total25 { get; set; }
        [DataMember]
        public Decimal Total35 { get; set; }
        [DataMember]
        public Decimal Total100 { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Int32? IdMovimientoCaja { get; set; }
        [DataMember]
        public Boolean FlagCena { get; set; }
        [DataMember]
        public Boolean FlagDesayuno { get; set; }
        [DataMember]
        public Boolean FlagCompensacion { get; set; }
        [DataMember]
        public Boolean FlagAprobado { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        [DataMember]
        public DateTime? FechaCompensacion { get; set; }

        [DataMember]
        public String Motivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Autorizado { get; set; }

        [DataMember]
        public Decimal TotalHoras { get; set; }
        [DataMember]
        public String TotalHorasFormato { get; set; }
        [DataMember]
        public Decimal TotalHorasContadas { get; set; }
        [DataMember]
        public Decimal SueldoBruto { get; set; }
        [DataMember]
        public Decimal SueldoHora { get; set; }
        [DataMember]
        public Decimal SueldoHoraNocturna { get; set; }
        [DataMember]
        public Decimal MontoPagar { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }

        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public DateTime? FechaMovimientoCaja { get; set; }
        [DataMember]
        public String NumeroEgreso { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String UsuarioAprobado { get; set; }
        [DataMember]
        public Int32? PeriodoPlanilla { get; set; }
        [DataMember]
        public Int32? MesPlanilla { get; set; }

        #endregion
    }
}
