using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteKardexBultoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public int IdEmpresa { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public String DescMaterial { get; set; }
        [DataMember]
        public Int32 StockBultos { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 StockCantidades { get; set; }
        [DataMember]
        public Int32 CantidadComprada { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public DateTime FechaCompra { get; set; }
        [DataMember]
        public DateTime FechaIngreso { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal PrecioABSoles { get; set; }
        [DataMember]
        public Decimal PrecioCDSoles { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }



        #endregion
    }
}
