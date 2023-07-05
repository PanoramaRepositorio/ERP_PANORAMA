using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteRotacionProductosBE
    {
        #region "Atributos"
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Int32 DiasSinRotacion { get; set; }
        [DataMember]
        public String Almacen { get; set; }
        #endregion
    }
}
