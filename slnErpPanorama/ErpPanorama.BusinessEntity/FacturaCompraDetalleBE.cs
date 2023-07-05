using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class FacturaCompraDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdFacturaCompraDetalle { get; set; }
        [DataMember]
        public Int32 IdFacturaCompra { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public Int32 NumeroBultos { get; set; }
        [DataMember]
        public Int32 Cantidad { get; set; }
        [DataMember]
        public Decimal PrecioUnitario { get; set; }
        [DataMember]
        public Decimal SubTotal { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }

        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Medida { get; set; }
        [DataMember]
        public Int32 IdUnidadMedida { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public byte[] Imagen { get; set; }
        [DataMember]
        public Int32 CantidadUM { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }

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
        public Decimal DescuentoAB { get; set; }
        [DataMember]
        public Boolean FlagDescuentoAB { get; set; }

        [DataMember]
        public Int32 AlmacenCentral { get; set; }
        [DataMember]
        public Int32 AlmacenTienda { get; set; }
        [DataMember]
        public Int32 AlmacenAndahuaylas { get; set; }
        [DataMember]
        public Int32 AlmacenOutlet { get; set; }
        [DataMember]
        public Int32 AlmacenPrescott { get; set; }
        [DataMember]
        public Int32 AlmacenAviacion { get; set; }
        [DataMember]
        public Int32 AlmacenAviacion2 { get; set; }
        [DataMember]
        public Int32 AlmacenSanMiguel { get; set; }
        [DataMember]
        public Int32 AlmacenMegaPlaza { get; set; }

        [DataMember]
        public Int32 TransAlmacenTienda { get; set; }
        [DataMember]
        public Int32 TransAlmacenAndahuaylas { get; set; }
        [DataMember]
        public Int32 TransAlmacenPrescott { get; set; }
        [DataMember]
        public Int32 TransAlmacenAviacion2 { get; set; }

        [DataMember]
        public Int32 TransAlmacenSanMiguel { get; set; }

        [DataMember]
        public Int32 TotalStock { get; set; }


        public Int32 CantidadVenta { get; set; }
        [DataMember]
        public Decimal ImporteVenta { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }

        [DataMember]
        public Decimal GastosAduanasC { get; set; }
        [DataMember]
        public Decimal FleteC { get; set; }
        [DataMember]
        public Decimal AdvaloremC { get; set; }
        [DataMember]
        public Decimal DesestibaC { get; set; }
        [DataMember]
        public Decimal SobreEstadiaC { get; set; }
        [DataMember]
        public Decimal TotalC { get; set; }
        [DataMember]
        public Decimal PUnitarioC { get; set; }
        [DataMember]
        public Decimal PesosC { get; set; }

        [DataMember]
        public Decimal Ipm { get; set; }
        [DataMember]
        public Decimal Igv { get; set; }
        [DataMember]
        public Decimal Percepcion { get; set; }
        #endregion
    }
}
