using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PreventaDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPreventaDetalle { get; set; }
        [DataMember]
        public Int32 IdPreventa { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 CantidadVenta { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        [DataMember]
        public Int32 IdTienda { get; set; }
                [DataMember]
        public Int32 IdFamiliaProducto { get; set; }
        [DataMember]
        public String DescFamiliaProducto { get; set; }

        [DataMember]
        public Int32 IdLineaProducto { get; set; }
                [DataMember]
        public Int32 IdMarca { get; set; }

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
        public Boolean FlagEscala { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }
        

        #endregion
    }
}

