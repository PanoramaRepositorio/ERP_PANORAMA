using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class StockBultoBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdStockBulto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioCostoPromedio { get; set; }
        [DataMember]
        public Decimal CostoTotal { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }


        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 ValorIncrementa { get; set; }
        [DataMember]
        public Int32 ValorDescuenta { get; set; }

        #endregion
    }
}
