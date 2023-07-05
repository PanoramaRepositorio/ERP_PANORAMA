using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Dis_DisenoVisitasRealizadasBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDis_ProyectoServicio { get; set; }
        [DataMember]
        public Int32 IdAgendaVisita { get; set; }
  

        [DataMember]
        public String NumAgendaVisita { get; set; }

        [DataMember]
        public String HoraInicio { get; set; }
        [DataMember]
        public String HoraFin { get; set; }
        [DataMember]
        public DateTime FechaAgenda { get; set; }

        [DataMember]
        public String MotivoVisita { get; set; }

        [DataMember]
        public String Agenda { get; set; }

        [DataMember]
        public String Disenador { get; set; }

        [DataMember]
        public decimal PrecioVisita { get; set; }

        [DataMember]
        public String Situacion { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
