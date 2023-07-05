using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteHorarioPersonaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DiaSemanaName { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String FechaIngreso { get; set; }
        [DataMember]
        public String FechaSalidaRef { get; set; }
        [DataMember]
        public String FechaIngresoRef { get; set; }
        [DataMember]
        public String FechaSalida { get; set; }
        [DataMember]
        public Decimal TotalHorasRef { get; set; }
        [DataMember]
        public Decimal TotalHorasTrab { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescTurno { get; set; }
        #endregion
    }
}
