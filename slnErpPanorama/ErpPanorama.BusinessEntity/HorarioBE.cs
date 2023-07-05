using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class HorarioBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdHorario { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String DescHorario { get; set; }
        [DataMember]
        public DateTime FechaIni { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        

        #endregion
    }
}
