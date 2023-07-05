using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class InventarioVisualBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdInventarioVisual { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdBloque { get; set; }
        [DataMember]
        public Int32 IdModulo { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public decimal DescuentoActual { get; set; }
        [DataMember]
        public decimal DescuentoSugerido { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public DateTime FechaCompra { get; set; }
        [DataMember]
        public Int32 CantidadCompra { get; set; }
        [DataMember]
        public Int32 Stock { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescBloque { get; set; }
        [DataMember]
        public String DescModulo { get; set; }

        #endregion
    }
}
