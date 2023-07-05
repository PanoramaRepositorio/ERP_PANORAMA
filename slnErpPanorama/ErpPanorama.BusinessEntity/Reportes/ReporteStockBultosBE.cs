using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteStockBultosBE
    {
        #region "Atributos"
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String SubLineaProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 AnioRecep { get; set; }
        [DataMember]
        public Int32 MesRecep { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        #endregion
    }
}
