using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MarcacionesBE
    {
        #region "Atributos"
        [DataMember]
        public Int32  Idhoraextra { get; set; }
        [DataMember]
        public String dni { get; set; }
        [DataMember]
        public Int32 Tipo { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Apellidos { get; set; }
        [DataMember]
        public String Fecha { get; set; }
        [DataMember]
        public String Marcacion { get; set; }
        [DataMember]
        public String FechaDesde { get; set; }
        [DataMember]
        public String FechaHasta { get; set; }
        [DataMember]
        public String Ingreso { get; set; }
        [DataMember]
        public String Salida { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        #endregion
    }
}
