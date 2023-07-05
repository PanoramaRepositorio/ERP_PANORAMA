using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteVacacionesVendidasBE
    {
        #region "Atributos"
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public String Periodo { get; set; }
        [DataMember]
        public DateTime FechaDesde { get; set; }
        [DataMember]
        public DateTime FechaHasta { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String Autorizado { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Boolean FlagGozo { get; set; }
        [DataMember]
        public Boolean FlagAdelantadas { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public String Observacion { get; set; }

        #endregion
    }
}
