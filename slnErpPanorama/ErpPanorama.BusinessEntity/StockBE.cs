using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class StockBE
    {
        #region "Atributos"

        [DataMember]
        public Int32 IdStock { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 Periodo { get; set; }
        [DataMember]
        public Int32 IdAlmacen { get; set; }
        [DataMember]
        public Int32 IdAlmacenOrigen { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Int32 CantidadNS { get; set; }
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
        public Int32 IdTienda { get; set; }
        [DataMember]
        public String DescTienda { get; set; }
        [DataMember]
        public String DescAlmacen { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public Int32 ValorIncrementa { get; set; }
        [DataMember]
        public Int32 ValorDescuenta { get; set; }
        [DataMember]
        public String DescUbicacion { get; set; }
        [DataMember]
        public Decimal PrecioAB { get; set; }
        [DataMember]
        public Decimal PrecioCD { get; set; }
        [DataMember]
        public Decimal PrecioABSoles { get; set; }
        [DataMember]
        public Decimal PrecioCDSoles { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Int32 IdFamiliaProducto { get; set; }
        [DataMember]
        public Int32 IdLineaProducto { get; set; }
        [DataMember]
        public Int32 IdMarca { get; set; }
        [DataMember]
        public String DescFamiliaProducto { get; set; }
        [DataMember]
        public Decimal CostoUnitario { get; set; }
        [DataMember]
        public Decimal CostoUnitarioSoles { get; set; }
        [DataMember]
        public Boolean FlagEscala { get; set; }
        [DataMember]
        public DateTime FechaCompra { get; set; }
        [DataMember]
        public Decimal DescuentoAB { get; set; }
        [DataMember]
        public Decimal DescuentoOutlet { get; set; }
        [DataMember]
        public Boolean FlagDescuentoAB { get; set; }
        [DataMember]
        public Boolean FlagAutoservicio { get; set; }
        [DataMember]
        public Int32 IdProductoArmado { get; set; }
        [DataMember]
        public Boolean FlagCompuesto { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }


        [DataMember]
        public String DescTipoDocumento { get; set; }
        [DataMember]
        public String Numero { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public String Origen { get; set; }
        [DataMember]
        public String Destino { get; set; }
        [DataMember]
        public Decimal Importe { get; set; }
        [DataMember]
        public String DescFormaPago { get; set; }
        [DataMember]
        public String DescSituacion { get; set; }
        [DataMember]
        public Int32 IdTipoProducto { get; set; }
        [DataMember]
        public Int32 CantidadPedida { get; set; }
        [DataMember]
        public String AbrevAlmacen { get; set; }
        [DataMember]
        public String Observacion { get; set; }
        [DataMember]
        public String DescVendedor { get; set; }
        [DataMember]
        public String DescCliente { get; set; }
        


        #endregion
    }
}
