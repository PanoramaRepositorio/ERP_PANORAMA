using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteFacturaCompraBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdFacturaCompra { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Int32 IdProveedor { get; set; }
        [DataMember]
        public String DescProveedor { get; set; }
        [DataMember]
        public Int32 IdFormaPago { get; set; }
        [DataMember]
        public DateTime FechaCompra { get; set; }
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
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 IdFacturaCompraDetalle { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 NumeroBultos { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public String FormaPago { get; set; }
        [DataMember]
        public String Moneda { get; set; }
        [DataMember]
        public Int32 CantidadTotal { get; set; }
        [DataMember]
        public Int32 Stock { get; set; }
        #endregion
    }
}