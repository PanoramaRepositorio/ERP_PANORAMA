using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteInventarioBultoSectorStockBE
    {
        #region "Atributos"
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public DateTime FechaRecepcion { get; set; }
        [DataMember]
        public Int32 StockInicial { get; set; }
        [DataMember]
        public Int32 StockActual { get; set; }

        #endregion
    }
}
