using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TempListaPrecioDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdListaPrecioDetalle { get; set; }
        [DataMember]
        public Int32 IdListaPrecio { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Decimal PrecioABSoles { get; set; }
        [DataMember]
        public Decimal PrecioCDSoles { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public String Operacion { get; set; }
        [DataMember]
        public DateTimeOffset? Fecha { get; set; }
        [DataMember]
        public String DescListaPrecio { get; set; }


        #endregion
    }
}
