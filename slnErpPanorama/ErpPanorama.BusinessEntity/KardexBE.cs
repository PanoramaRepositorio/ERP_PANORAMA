using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class KardexBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdKardex { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String TipoMovimiento { get; set; }
        [DataMember]
        public DateTime? FechaMovimiento { get; set; }
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
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public Int32 IdTipoDocumento { get; set; }
        [DataMember]
        public String NumeroDocumento { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String DescAlmacenOrigen { get; set; }
        
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String CodTipoDocumento { get; set; }
        [DataMember]
        public Int32 Ingresos { get; set; }
        [DataMember]
        public Int32 Salidas { get; set; }
        [DataMember]
        public Int32 Stock { get; set; }
        [DataMember]
        public Int32 StockTransito { get; set; }
        [DataMember]
        public Int32 Saldo { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }

        [DataMember]
        public Int32 Stock2 { get; set; }


        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Decimal CostoPromedio { get; set; }
        [DataMember]
        public Decimal TotalCostoUnitario { get; set; }
        [DataMember]
        public Decimal TotalCostoPromedio { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }

        [DataMember]
        public DateTime? FechaRegistro { get; set; }
        [DataMember]
        public DateTime? FechaRecepcion { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        

        #endregion
    }
}
