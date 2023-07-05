using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Dis_DisenoEsteticoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdDis_DisenoEstetico { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdDis_ProyectoServicio { get; set; }
        [DataMember]
        public String Objetivos { get; set; }
        [DataMember]
        public Int32 IdDis_Estilo { get; set; }
        [DataMember]
        public Int32 IdDis_Forma { get; set; }
        [DataMember]
        public String DescVolumen { get; set; }
        [DataMember]
        public String DescTextura { get; set; }
        [DataMember]
        public Int32 IdMaterial { get; set; }
        [DataMember]
        public Int32 IdDis_TipoColor { get; set; }
        [DataMember]
        public String DescDis_Estilo { get; set; }
        [DataMember]
        public String DescDis_Forma { get; set; }
        [DataMember]
        public String DescMaterial { get; set; }
        [DataMember]
        public String DescDis_TipoColor { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
