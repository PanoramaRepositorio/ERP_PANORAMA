using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteKardexSalidasBE
    {
        #region "Atributos"

        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public int IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescSubLinea { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
 
        #endregion
    }
}
