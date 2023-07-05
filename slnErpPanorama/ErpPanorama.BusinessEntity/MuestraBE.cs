using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MuestraBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdMuestra { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }


        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public String DescModeloProducto { get; set; }
        [DataMember]
        public String DescMaterial { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }
        [DataMember]
        public Decimal StockAlmacenUcayali { get; set; }
        [DataMember]
        public Decimal StockTiendaUcayali { get; set; }


        #endregion
    }
}
