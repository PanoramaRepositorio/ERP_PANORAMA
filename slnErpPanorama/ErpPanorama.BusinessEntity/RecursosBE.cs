using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class RecursosBE
    {
        #region "Atributos"

        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string ApeNom { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime? FechaDesde { get; set; }
        [DataMember]
        public DateTime? FechaHasta { get; set; }
        [DataMember]
        public string TiempoTrabajado { get; set; }
        #endregion
    }
}