using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProductoTransformacionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProductoTransformacion { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal Costo { get; set; }
        [DataMember]
        public Decimal Margen { get; set; }
        [DataMember]
        public Decimal PrecioSoles { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal PrecioDolar { get; set; }
        [DataMember]
        public Int32 IdMovimientoAlmacen { get; set; }
        [DataMember]
        public Int32 IdProforma { get; set; }
        [DataMember]
        public String NumeroProforma { get; set; }
        [DataMember]
        public String NumeroFactura { get; set; }
        [DataMember]
        public DateTime? Fecha { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        #endregion
    }
}
