using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PromocionBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPromocion { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public Decimal MontoMin { get; set; }
        [DataMember]
        public Decimal MontoMax { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }


        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

///-----------
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }

        [DataMember]
        public String DescUbicacion { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }
        [DataMember]
        public Decimal PrecioABSoles { get; set; }
        [DataMember]
        public Decimal PrecioCDSoles { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal DescuentoOutlet { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 IdLineaProducto { get; set; }
        [DataMember]
        public Boolean FlagEscala { get; set; }

        #endregion

    }
}
