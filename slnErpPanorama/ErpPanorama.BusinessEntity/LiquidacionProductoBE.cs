using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class LiquidacionProductoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdLiquidacionProducto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        #endregion
    }
}
