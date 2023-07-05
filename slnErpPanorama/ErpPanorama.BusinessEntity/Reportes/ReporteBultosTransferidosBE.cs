using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteBultosTransferidosBE
    {
        #region "Atributos"

        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String NumeroBulto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String DescBloque { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public DateTime FechaSalida { get; set; }

        #endregion
    }
}
