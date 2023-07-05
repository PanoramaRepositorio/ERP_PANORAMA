using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class FacturaCompraBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdFacturaCompra { get; set; }
        [DataMember]
        public Int32 IdFacturaCompraDetalle { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public Int32? IdMotivoVenta { get; set; }
        [DataMember]
        public Int32? IdSituacionPago { get; set; }
        [DataMember]
        public DateTime FechaCompra { get; set; }
        [DataMember]
        public DateTime? FechaRecepcion { get; set; }
        [DataMember]
        public DateTime? FechaVencimiento{ get; set; }
        [DataMember]
        public String TipoRegistro { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Decimal GastosAdministrativos { get; set; }
        [DataMember]
        public Decimal Flete { get; set; }
 
        [DataMember]
        public Decimal Ipm { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal Advalorem { get; set; }
        [DataMember]
        public Decimal Percepcion { get; set; }

        [DataMember]
        public Decimal Ipm2 { get; set; }
        [DataMember]
        public Decimal Igv2 { get; set; }
        [DataMember]
        public Decimal Advalorem2 { get; set; }
        [DataMember]
        public Decimal Percepcion2 { get; set; }

        [DataMember]
        public Decimal DerechosPercepcion { get; set; }
        [DataMember]
        public Decimal Desestiba { get; set; }

        [DataMember]
        public Decimal Desestiba2 { get; set; }
        [DataMember]
        public Decimal SobreEstadia { get; set; }

        [DataMember]
        public String NroDUA { get; set; }
        [DataMember]
        public int TamañoContenedor { get; set; }

        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Decimal ImportePago { get; set; }
        [DataMember]
        public Decimal? ImportePorPagar { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagRecibido { get; set; }
        [DataMember]
        public Int32? IdSolicitudCompra { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public Boolean vNacionales { get; set; }

        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public String FormaPago { get; set; }
        [DataMember]
        public String SituacionPago { get; set; }
        [DataMember]
        public String MotivoVenta { get; set; }
        [DataMember]
        public String Moneda { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Boolean FlagMuestra { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }
        [DataMember]
        public Boolean FlagPagado { get; set; }

        [DataMember]
        public Decimal PorcentajeVenta { get; set; }
        [DataMember]
        public Int32 CantidadVenta { get; set; }
        [DataMember]
        public Decimal ImporteVenta { get; set; }

        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public Decimal Enero { get; set; }
        [DataMember]
        public Decimal Febrero { get; set; }
        [DataMember]
        public Decimal Marzo { get; set; }
        [DataMember]
        public Decimal Abril { get; set; }
        [DataMember]
        public Decimal Mayo { get; set; }
        [DataMember]
        public Decimal Junio { get; set; }
        [DataMember]
        public Decimal Julio { get; set; }
        [DataMember]
        public Decimal Agosto { get; set; }
        [DataMember]
        public Decimal Setiembre { get; set; }
        [DataMember]
        public Decimal Octubre { get; set; }
        [DataMember]
        public Decimal Noviembre { get; set; }
        [DataMember]
        public Decimal Diciembre { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }

        #endregion
    }
}
