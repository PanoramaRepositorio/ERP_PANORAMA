using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteDocumentoReferenciaBE
    {
        #region "Atributos"

        [DataMember]
        public String NumeroPedido { get; set; }
        [DataMember]
        public String Serie { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public DateTime FechaReferencia { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public String CodMoneda { get; set; }
        [DataMember]
        public String DescMoneda { get; set; }
        
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal Total { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioVenta { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescTipoAplicacion { get; set; }

        #endregion
    }
}
