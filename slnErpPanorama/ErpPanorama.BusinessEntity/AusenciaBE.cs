using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AusenciaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAusencia { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public DateTime FechaDesde { get; set; }
        [DataMember]
        public DateTime FechaHasta { get; set; }
        [DataMember]
        public Int32 Dias { get; set; }
        [DataMember]
        public Int32 IdMotivoAusencia { get; set; }
        [DataMember]
        public Int32 IdAutorizado { get; set; }
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
        public String Dni { get; set; }
        [DataMember]
        public String DescMotivoAusencia { get; set; }
        [DataMember]
        public String Autorizado { get; set; }
        [DataMember]
        public Int32? IdPersonaCalendarioLaboral { get; set; }
        [DataMember]
        public DateTime? FechaRecupera { get; set; }

        [DataMember]
        public String AsistenciaRecupera { get; set; }
        
        #endregion
    }
}
