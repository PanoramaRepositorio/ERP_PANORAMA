using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class IncidenciaBE
    {
        [DataMember]
        public Int32 IdIncidencia { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdSolicitante { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Solucion { get; set; }
        [DataMember]
        public Int32? IdResponsable { get; set; }
        [DataMember]
        public DateTime? FechaCierre { get; set; }
        [DataMember]
        public DateTime? FechaLimite { get; set; }
        [DataMember]
        public Int32 IdPrioridad { get; set; }
        [DataMember]
        public Int32 IdEstado { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Int32 RowNumber { get; set; }
        [DataMember]
        public String Solicitante { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String Responsable { get; set; }
        [DataMember]
        public String DescPrioridad { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
    }
}
