using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReportePersonaTrabajoBE
    {
        #region "Atributos"
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public DateTime HoraInicio { get; set; }
        [DataMember]
        public DateTime HoraFin { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DiaSemana { get; set; }
        [DataMember]
        public String DiaFeriado { get; set; }

        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String ObservacionDetalle { get; set; }
        [DataMember]
        public String Apoyo { get; set; }
        [DataMember]
        public String Item { get; set; }

        #endregion
    }
}
