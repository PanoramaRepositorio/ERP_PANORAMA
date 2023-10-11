using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ErpPanorama.BusinessEntity
{
    [DataContract]
    public class PromocionVolumenDetalleBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdPromocionVolumenDetalle { get; set; }
        [DataMember]
        public Int32 IdPromocionVolumen { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 IdProducto { get; set; }
        [DataMember]
        public String CodigoProveedor { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public String Abreviatura { get; set; }
        [DataMember]
        public String DescLineaProducto { get; set; }
        [DataMember]
        public String DescSubLineaProducto { get; set; }
        [DataMember]
        public Decimal Precio { get; set; }
        [DataMember]
        public Decimal Precio2 { get; set; }
        [DataMember]
        public Decimal Descuento { get; set; }
        [DataMember]
        public Decimal DsctoEcommerce { get; set; }
        [DataMember]
        public Decimal DescuentoActual { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public Boolean FlagClienteMayorista { get; set; }
        [DataMember]
        public Boolean FlagClienteFinal { get; set; }



        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public Int32 CantidadCompra { get; set; }
        [DataMember]
        public Int32 AlmacenCentral { get; set; }
        [DataMember]
        public Int32 AlmacenTienda { get; set; }
        [DataMember]
        public Int32 AlmacenAndahuaylas { get; set; }
        [DataMember]
        public Int32 AlmacenPrescott { get; set; }
        [DataMember]
        public Int32 AlmacenAviacion { get; set; }
        [DataMember]
        public Int32 AlmacenMegaPlaza { get; set; }
        [DataMember]
        public Boolean FlagNacional { get; set; }
        [DataMember]
        public Int32 AlmacenAviacion2 { get; set; }

        [DataMember]
        public Int32 AlmacenSanMiguel { get; set; }

        [DataMember]
        public Decimal MontoSoloXUni { get; set; }

        [DataMember]
        public Decimal MontoUniXamas { get; set; }


        #endregion

    }
}
