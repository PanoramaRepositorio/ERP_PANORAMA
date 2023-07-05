using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class MovimientoAlmacenDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdMovimientoAlmacenDetalle { get; set; }
        [DataMember]
        public Int32 IdMovimientoAlmacen { get; set; }
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
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 CantidadAnt { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Int32 CantidadChequeo { get; set; }

        #endregion

    }
}
