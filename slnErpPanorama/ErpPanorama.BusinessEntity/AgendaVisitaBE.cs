using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AgendaVisitaBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdAgendaVisita { get; set; }
        [DataMember]
        public String NumAgendaVisita { get; set; }

        [DataMember]
        public String NumProyecto { get; set; }

        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public Int32 IdAsesor { get; set; }

        [DataMember]
        public DateTime FechaAgendaVisita { get; set; }
        [DataMember]
        public DateTime FechaAgenda { get; set; }
        [DataMember]
        public String StrFechaAgenda { get; set; } // <- 170323
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String Tienda { get; set; }

        [DataMember]
        public String Hora { get; set; }

        [DataMember]
        public int IdMotivo { get; set; }

        [DataMember]
        public String DescMotivo { get; set; }

        [DataMember]
        public Int32 IdPersona { get; set; }

        [DataMember]
        public Int32 IdCliente { get; set; }

        [DataMember]
        public String DescCliente { get; set; }

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String Disenadora { get; set; }


        [DataMember]
        public String Lugar { get; set; }

        [DataMember]
        public String RutaArchivo { get; set; }

        [DataMember]
        public String fname { get; set; }

        [DataMember]
        public String Tipo { get; set; }

        [DataMember]
        public String Distrito { get; set; }

        [DataMember]
        public String Agenda { get; set; }

        [DataMember]
        public String Celular { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public int IdSituacion { get; set; }
        [DataMember]
        public String Situacion { get; set; }

        [DataMember]
        public String Ubigeo { get; set; }

        [DataMember]
        public int Duracion { get; set; }

        [DataMember]
        public String DescCancelacion { get; set; }

        [DataMember]
        public String PuntosTratados { get; set; }

        [DataMember]
        public String TiempoTermino { get; set; }

        [DataMember]
        public Int32 TotalCancelado { get; set; }
        [DataMember]
        public Int32 TotalProgramado { get; set; }
        [DataMember]
        public Int32 TotalReProgramado { get; set; }
        [DataMember]
        public Int32 TotalVisitado { get; set; }
        [DataMember]
        public Decimal PrecioVisita { get; set; }
        [DataMember]
        public String DiaSemana { get; set; }
        [DataMember]
        public String NumeroProyecto { get; set; }
        #endregion
    }
}