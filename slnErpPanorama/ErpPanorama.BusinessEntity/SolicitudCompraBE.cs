using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class SolicitudCompraBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdSolicitudCompra { get; set; }
        [DataMember]
        public Int32 IdSolicitudCompraDetalle { get; set; }
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
        public DateTime FechaCompra { get; set; }
        [DataMember]
        public DateTime? FechaEmbarque { get; set; }
        [DataMember]
        public DateTime? FechaRecepcion { get; set; }
        [DataMember]
        public String TipoRegistro { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public Int32 IdMoneda { get; set; }
        [DataMember]
        public Decimal TipoCambio { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 Items { get; set; }
        [DataMember]
        public Int32 DiasCredito { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Boolean FlagRecibido { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
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
        public String DescLineaProducto { get; set; }

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
        [DataMember]
        public String NumeroFactura { get; set; }
        

        #endregion
    }
}
