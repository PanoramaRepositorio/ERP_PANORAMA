using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReservaSalaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdReserva { get; set; }
        [DataMember]
        public DateTime FecReserva { get; set; }
        [DataMember]
        public Int32 IdHora { get; set; }
        [DataMember]
        public String Hora { get; set; }

        [DataMember]
        public String Agenda { get; set; }

        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdDuracion { get; set; }

        [DataMember]
        public String Reservo { get; set; }

        [DataMember]
        public DateTime HoraInicio { get; set; }

        [DataMember]
        public DateTime HoraFin { get; set; }
        #endregion
    }
}
