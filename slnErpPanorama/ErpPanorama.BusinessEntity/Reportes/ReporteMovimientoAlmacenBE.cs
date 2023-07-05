using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class ReporteMovimientoAlmacenBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdMovimientoAlmacen { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public Int32 IdTipoMovimiento { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 IdAlmacenOrigen { get; set; }
        [DataMember]
        public Int32 IdMotivo { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public String Referencia { get; set; }
        [DataMember]
        public String Observaciones { get; set; }
        [DataMember]
        public Int32 IdAlmacenDestino { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }

        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescMotivo { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public Int32 IdMovimientoAlmacenDetalle { get; set; }
        [DataMember]
        public Int32 Item { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Decimal MontoTotal { get; set; }
        [DataMember]
        public Int32? IdKardex { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }

        [DataMember]
        public String DescAlmacenDestino { get; set; }

        #endregion
    }
}
