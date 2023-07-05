using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteProductoCatalogoFacturaBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String CodigoPanorama { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public String DescMaterial { get; set; }
        [DataMember]
        public String DescMarca { get; set; }
        [DataMember]
        public String DescProcedencia { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public Decimal Peso { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String CodigoBarra { get; set; }
        [DataMember]
        public byte[] Imagen { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal DescuentoAB { get; set; }
        [DataMember]
        public Boolean FlagDescuentoAB { get; set; }
        [DataMember]
        public Int32 StockBultos { get; set; }
        [DataMember]
        public Int32 StockCantidades { get; set; }
        [DataMember]
        public Boolean FlagCompuesto { get; set; }
        [DataMember]
        public Boolean FlagObsequio { get; set; }
        [DataMember]
        public Boolean FlagEscala { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Decimal TipoCambioMinorista { get; set; }

 
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Decimal TcListaPrecioCD { get; set; }        

        #endregion
    }
}
