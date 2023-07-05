using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class DocumentoVentaDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdDocumentoVentaDetalle { get; set; }
        [DataMember]
        public Int32 IdDocumentoVenta { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal ValorUnitario { get; set; }
        [DataMember]
        public Decimal TotalValor { get; set; }
        [DataMember]
        public Decimal ValorUnitDscto { get; set; }
        [DataMember]
        public Decimal TotalValorUnitDscto { get; set; }

        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal TotalUnitario { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal ICBPER { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public String CodAfeIGV { get; set; }
        [DataMember]
        public Int32? IdKardex { get; set; }
        [DataMember]
        public Boolean FlagMuestra { get; set; }
        [DataMember]
        public Boolean FlagRegalo { get; set; }
        [DataMember]
        public Int32? IdPromocion { get; set; }
        [DataMember]
        public String DescPromocion { get; set; }

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
        public Int32 CantidadAnt { get; set; }
        [DataMember]
        public Int32 IdFamiliaProducto { get; set; }
        [DataMember]
        public Int32 IdLineaProducto { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuentoInicial { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Decimal PrecioUnitarioPedido { get; set; }
        [DataMember]
        public Decimal PrecioVentaPedido { get; set; }
        [DataMember]
        public Decimal ValorVentaSoles { get; set; }
        [DataMember]
        public Decimal ValorVentaDolares { get; set; }
        [DataMember]
        public Int32 IdTienda { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32 IdProductoArmado { get; set; }
        //[DataMember]
        //public Decimal DescuentoOutlet { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Boolean FlagCompuesto { get; set; }

        [DataMember]
        public String Observ { get; set; }

        [DataMember]
        public String DescFamiliaProducto { get; set; }
        [DataMember]
        public Int32 IdMarca { get; set; }
        [DataMember]
        public String ObsEscala { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }
        [DataMember]
        public Boolean FlagEscala { get; set; }

        [DataMember]
        public Int32 IdPromocion2 { get; set; }
        [DataMember]
        public Decimal PorcentajePromocionDetalle { get; set; }
        #endregion
    }
}
