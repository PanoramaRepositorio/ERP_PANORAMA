using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class AccesoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPerfil { get; set; }
        [DataMember]
        public Int32 IdMenu { get; set; }
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
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipOper { get; set; }
        #endregion
    }
}
