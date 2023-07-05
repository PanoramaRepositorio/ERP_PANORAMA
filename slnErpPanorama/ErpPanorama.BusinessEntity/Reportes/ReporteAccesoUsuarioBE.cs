using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteAccesoUsuarioBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdUser { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public Int32 IdPerfil { get; set; }
        [DataMember]
        public String DescPerfil { get; set; }
        [DataMember]
        public Int32 IdMenu { get; set; }
        [DataMember]
        public String MenuDescripcion { get; set; }
        [DataMember]
        public Boolean FlagLectura { get; set; }
        [DataMember]
        public Boolean FlagAdicion { get; set; }
        [DataMember]
        public Boolean FlagActualizacion { get; set; }
        [DataMember]
        public Boolean FlagEliminacion { get; set; }
        [DataMember]
        public Boolean FlagImpresion { get; set; }
        #endregion
    }
}
