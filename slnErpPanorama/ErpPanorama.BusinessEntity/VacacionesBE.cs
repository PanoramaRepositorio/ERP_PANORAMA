using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class VacacionesBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdVacaciones { get; set; }
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
        public Int32 IdAutorizado { get; set; }

        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Boolean FlagGozo { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
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
        public String DescSituacion { get; set; }
        [DataMember]
        public String Autorizado { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescCargo { get; set; }

        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public Boolean FlagAdelantadas { get; set; }
        #endregion
    }
}
