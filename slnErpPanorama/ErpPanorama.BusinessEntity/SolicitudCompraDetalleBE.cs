using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudCompraDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSolicitudCompraDetalle { get; set; }
        [DataMember]
        public Int32 IdSolicitudCompra { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 NumeroBultos { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public String CBM { get; set; }
        [DataMember]
        public Decimal Peso { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        public String CodigoProveedor { get; set; }


        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public byte[] Imagen { get; set; }
        [DataMember]
        public Int32 CantidadUM { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

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
        public Decimal DescuentoAB { get; set; }
        [DataMember]
        public Boolean FlagDescuentoAB { get; set; }





        #endregion
    }
}
