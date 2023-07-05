using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AgendaVisitaDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdAgendaVisita { get; set; }
        [DataMember]
        public Int32 IdAgendaVisitaDetalle { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String Lugar   { get; set; }
        [DataMember]
        public String Ubigeo { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public String DuracionAprox { get; set; }
        [DataMember]
        public Int32 IdMotivoVisita { get; set; }
        [DataMember]
        public String AdjuntarFicha { get; set; }
        [DataMember]
        public String AdjuntarChecklist { get; set; }
        [DataMember]
        public String Detalle { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        #endregion
    }
}
