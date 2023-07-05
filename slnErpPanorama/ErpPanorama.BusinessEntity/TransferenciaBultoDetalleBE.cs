using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class TransferenciaBultoDetalleBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdTransferenciaBultoDetalle { get; set; }
        [DataMember]
        public Int32 IdTransferenciaBulto { get; set; }
        [DataMember]
        public Int32 IdBulto { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 IdKardexBulto { get; set; }
        [DataMember]
        public Int32 IdKardex { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        public String NumeroBulto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

        #endregion
    }
}
