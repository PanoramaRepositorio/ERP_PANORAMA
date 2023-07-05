using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteHoraExtraBE
    {
        #region "Atributos"
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public DateTime FechaDesde { get; set; }
        [DataMember]
        public DateTime FechaHasta { get; set; }
        [DataMember]
        public Decimal TotalHoras { get; set; }
        [DataMember]
        public String TotalHorasFormato { get; set; }
        [DataMember]
        public Decimal TotalHorasContadas { get; set; }
        [DataMember]
        public Decimal TotalExtraNormal { get; set; }
        [DataMember]
        public Decimal TotalExtraNocturno { get; set; }
        [DataMember]
        public Decimal SueldoExtraNocturno { get; set; }
        [DataMember]
        public Decimal SueldoBruto { get; set; }
        [DataMember]
        public Decimal SueldoHora { get; set; }
        [DataMember]
        public Decimal SueldoHoraNocturna { get; set; }
        [DataMember]
        public Decimal MontoPagar { get; set; }

        [DataMember]
        public String Autorizado { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescCaja { get; set; }
        [DataMember]
        public DateTime FechaMovimientoCaja { get; set; }
        [DataMember]
        public String NumeroEgreso { get; set; }
        [DataMember]
        public Boolean FlagCena { get; set; }
        [DataMember]
        public Boolean FlagDesayuno { get; set; }
        [DataMember]
        public Boolean FlagCompensacion { get; set; }
        [DataMember]
        public Boolean FlagAprobado { get; set; }
        [DataMember]
        public DateTime FechaCompensacion { get; set; }
        [DataMember]
        public String Motivo { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String DescCargo { get; set; }

        #endregion
    }
}
