using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ParametroBE
    {
        #region "Atributos"
        [DataMember]
        public string IdParametro { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Valor { get; set; }
        [DataMember]
        public Decimal Numero { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public DateTime FechaCreacion { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }

        #endregion
    }
}
