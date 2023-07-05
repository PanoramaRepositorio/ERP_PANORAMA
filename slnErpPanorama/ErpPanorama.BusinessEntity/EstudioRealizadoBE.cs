using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class EstudioRealizadoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdEstudioRealizado { get; set; }
        [DataMember]
        public Int32 IdPersona { get; set; }
        [DataMember]
        public Int32 IdNivelEstudio { get; set; }
        [DataMember]
        public String CentroEstudio { get; set; }
        [DataMember]
        public String GradoObtenido { get; set; }
        [DataMember]
        public String MesAnioIncio { get; set; }
        [DataMember]
        public String MesAnioFin { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        public String DescNivelEstudio { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        #endregion
    }
}
