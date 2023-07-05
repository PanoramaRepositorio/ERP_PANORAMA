using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity.Reportes
{
    [DataContract]
    public class ReportePedidoBE
    {
        #region "Atributos"
       
               
               

        [DataMember]
        public Int32 IdPedido { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 IdCliente { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String DescTipoCliente { get; set; }
        [DataMember]
        public Int32 IdTipoCliente { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public Int32 IdSituacion { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Boolean FlagPreVenta { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public Boolean FlagCompraPerfecta { get; set; }
        [DataMember]
        public Boolean FlagAuditado { get; set; }
        [DataMember]
        public DateTime? FechaAuditado { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String Add_user { get; set; }

        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
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
        
        #endregion

        
    }
}
