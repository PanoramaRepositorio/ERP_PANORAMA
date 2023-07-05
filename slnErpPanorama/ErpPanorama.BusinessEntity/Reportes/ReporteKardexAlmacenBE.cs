using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteKardexAlmacenBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public Int32 IdKardex { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public DateTime FechaMovimiento { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public Int32 Ingresos { get; set; }
        [DataMember]
        public Int32 Salidas { get; set; }
        [DataMember]
        public Int32 Stock { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
        [DataMember]
        public String Usuario { get; set; }

        #endregion
    }
}
