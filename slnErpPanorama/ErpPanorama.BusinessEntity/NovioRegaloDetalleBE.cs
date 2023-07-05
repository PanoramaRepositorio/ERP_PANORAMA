using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class NovioRegaloDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdNovioRegaloDetalle { get; set; }
        [DataMember]
        public Int32 IdNovioRegalo { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
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
        public Int32 CantidadStock { get; set; }
        [DataMember]
        public Int32 CantidadCompra { get; set; }
        [DataMember]
        public Int32 CantidadSaldo { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagComprado { get; set; }
        [DataMember]
        public Boolean FlagComprar { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        [DataMember]
        public Int32 IdLineaProducto { get; set; }
        #endregion

    }
}


