using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteNovioRegaloBE
    {
        #region "Atributos"
        [DataMember]
        public String RazonSocial { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String CodigoNovio { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String DniNovio { get; set; }
        [DataMember]
        public String DescNovio { get; set; }
        [DataMember]
        public String DniNovia { get; set; }
        [DataMember]
        public String DescNovia { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Celular { get; set; }
        [DataMember]
        public String Email { get; set; }
        [DataMember]
        public String Email2 { get; set; }
        [DataMember]
        public String Direccion { get; set; }
        [DataMember]
        public DateTime FechaBoda { get; set; }
        [DataMember]
        public String DescAsesor { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String Item { get; set; }
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
        public String ObservacionDetalle { get; set; }
        [DataMember]
        public String Comprado { get; set; }
        [DataMember]
        public Boolean FlagComprado { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }


        #endregion
    }
}
