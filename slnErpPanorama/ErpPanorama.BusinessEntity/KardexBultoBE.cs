using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class KardexBultoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdKardexBulto { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdSector { get; set; }
        [DataMember]
        public Int32 IdBloque { get; set; }
        [DataMember]
        public Int32 IdBulto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public DateTime FechaMovimiento { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public Decimal MontoUnitarioCompra { get; set; }
        [DataMember]
        public Decimal PrecioCostoPromedio { get; set; }
        [DataMember]
        public Decimal MontoTotalCompra { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }


        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public string NumeroDocumento { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescSector { get; set; }
        [DataMember]
        public String DescBloque { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 StockBultos { get; set; }
        [DataMember]
        public Int32 StockCantidades { get; set; }
        [DataMember]
        public String NumeroBulto { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public Int32 Ingresos { get; set; }
        [DataMember]
        public Int32 Salidas { get; set; }
        [DataMember]
        public Int32 Stock { get; set; }
        [DataMember]
        public Int32 Saldo { get; set; }

        #endregion
    }
}

