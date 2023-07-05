using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteVacacionesDiasBE
    {
        #region "Atributos"
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
        public String Dni { get; set; }
        [DataMember]
        public String ApeNom { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public Int32 DiasVacaciones { get; set; }
        [DataMember]
        public String DescCargo { get; set; }
        [DataMember]
        public String DescArea { get; set; }
        #endregion
    }
}
