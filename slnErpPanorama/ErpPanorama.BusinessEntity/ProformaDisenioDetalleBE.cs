using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ProformaDisenioDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdProformaDisenio { get; set; }
        [DataMember]
        public Int32 IdProformaDisenioDetalle { get; set; }
        [DataMember]
        public Int32 IdSituacionProducto { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Modelo { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String Material { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }

        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal PorcentajeDescuento { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal ValorVenta { get; set; }

        [DataMember]
        public byte[] Imagen { get; set; }

        [DataMember]
        public Boolean FlagObsequio { get; set; }
        [DataMember]
        public Boolean FlagModificado { get; set; }
        [DataMember]
        public Boolean FlagAprobadoDiseno { get; set; }
        [DataMember]
        public Boolean FlagAprobado { get; set; }

        [DataMember]
        public DateTime? FechaAprobadoDiseo { get; set; }
        [DataMember]
        public DateTime? FechaAprobado { get; set; }
        [DataMember]
        public DateTime? FechaEntrega { get; set; }

        [DataMember]
        public String Observacion { get; set; }
        #endregion
    }
}
