using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AnuncioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAnuncio { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DescAnuncio { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFin { get; set; }
        [DataMember]
        public Int32 IdTipoAnuncio { get; set; }
        [DataMember]
        public String DescTipoAnuncio { get; set; }
        [DataMember]
        public String Titulo { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
