using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProductoIncentivadoDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdProductoIncentivadoDetalle { get; set; }
        [DataMember]
        public Int32 IdProductoIncentivado { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal PrecioABSoles { get; set; }
        [DataMember]
        public Decimal PrecioCDSoles { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal Costo { get; set; }
        [DataMember]
        public Decimal Incentivo { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }

        //[DataMember]
        //public DateTime FechaRegistro { get; set; }

        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
