using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class Marcaciones2BE
    {
        #region "Atributos"
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String Fecha { get; set; }
       [DataMember]
        public String Fecha1 { get; set; }
        [DataMember]
        public String Fecha2 { get; set; }
        [DataMember]
        public String Ingreso{ get; set; }
        [DataMember]
        public String SalidaAlmuerzo { get; set; }
        [DataMember]
        public String IngresoAlmuerzo { get; set; }
        [DataMember]
        public String Salida { get; set; }
        [DataMember]
        public String PrimerPeriodo { get; set; }
        [DataMember]
        public String SegundoPeriodo { get; set; }
        [DataMember]
        public String TotalPeriodoTrabajado { get; set; }
        #endregion
    }
}
